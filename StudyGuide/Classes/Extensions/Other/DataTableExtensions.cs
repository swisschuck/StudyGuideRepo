using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudyGuide.Classes.Extensions.Other
{
    public static class DataTableExtensions
    {
        public static DataTable ToDataTable<T>(this List<T> items)
        {
            //var tb = new DataTable(typeof(T).Name);

            //PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var prop in props)
            //{
            //    tb.Columns.Add(prop.Name, prop.PropertyType);
            //}

            //foreach (var item in items)
            //{
            //    var values = new object[props.Length];
            //    for (var i = 0; i < props.Length; i++)
            //    {
            //        values[i] = props[i].GetValue(item, null);
            //    }

            //    tb.Rows.Add(values);
            //}

            //return tb;


            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            }
            foreach (T item in items)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }

                table.Rows.Add(row);
            }
            return table;
        }
    }
}

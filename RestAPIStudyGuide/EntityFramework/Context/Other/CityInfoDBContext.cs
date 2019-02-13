using Microsoft.EntityFrameworkCore;
using RestAPIStudyGuide.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPIStudyGuide.EntityFramework.Context.Other
{
    public class CityInfoDBContext : DbContext
    {
        #region fields
        #endregion fields


        #region properties

        public DbSet<CityDto> Cities { get; set; }

        public DbSet<PointOfInterestDto> PointsOfInterest { get; set; }

        #endregion properties


        #region constructors

        // this is the preffered way to get the options to the db context, injecting it through the constructor will ensure a cleaner setup and that
        // this DBContext will also get initialized with the correct options.
        public CityInfoDBContext(DbContextOptions<CityInfoDBContext> dbContextOptions) : base(dbContextOptions)
        {
            // if the database already exists then this line will do nothing, however if for some reason the DB has not been 
            // created then this will make sure it happens.
            Database.EnsureCreated();
        }


        #endregion constructors


        #region public methods

        // here is one of many ways to configure the DB context so it knows about the SQL server.
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // we need to configure the DB context so it knows what database to use
        //    optionsBuilder.UseSqlServer("connection string goes here");

        //    base.OnConfiguring(optionsBuilder);
        //}

        #endregion public methods


        #region private methods
        #endregion private methods
    }
}

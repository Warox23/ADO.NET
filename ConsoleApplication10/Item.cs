using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using System.Collections;


namespace ConsoleApplication10
{

    public class Items 
    {
        public List<Item> Itms { get; set; }

        public Items()
        {
            Itms = new List<Item>();
        }

        public Items(List<Item> items)
        {
            Itms = items;
        }

    }

    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<position> positionsHistory { get; set; }
        public List<job> jobHistory { get; set; }

        public Item()
        {
            positionsHistory = new List<position>();
            jobHistory = new List<job>();
        }

        public Item(int id, string fn, string ln, List<position> pos, List<job> jobs)
        {
            Id = id;
            FirstName = fn;
            LastName = ln;
            positionsHistory = pos;
            jobHistory = jobs;
        }

    }
    public class position
    {
        [XmlIgnore]
        [Key]
        public int Id { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
        public int Accuracy { get; set; }
        public DateTime time { get; set; }

        public position() { }


        public position(long lat, long lon, int acc, DateTime t)
        {
            Latitude = lat;
            Longitude = lon;
            Accuracy = acc;
            time = t;

        }

    }

    public class job
    {
        [XmlIgnore]
        [Key]
        public int Id { get; set; }
        public DateTime time { get; set; }
        public string decription { get; set; }
        public string Phone { get; set; }
        public string Userid { get; set; }

        public job() { }

        public job(DateTime t, string desk, string ph, string usid)
        {
            time = t;
            decription = desk;
            Phone = ph;
            Userid = usid;

        }

    }


    public class ItemContext : DbContext
    {
        public ItemContext() : base("DbConnect") { }
        public DbSet<Item> Items { get; set; }
        public DbSet<job> jobs { get; set; }
        public DbSet<position> positions { get; set; }
    }

}




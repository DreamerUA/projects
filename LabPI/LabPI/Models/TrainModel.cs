using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LabPI.Models
{
    public class TrainModel
    {
        public int ?lid { get; set; }
        public bool granted { get; set; }
        public string nstotpr { get; set; }
        public string nstprib { get; set; }
        //public Trains[] trains { get; set; }
        public List<Trains>  trains{get; set;}
    }

    public class Trains
    {
        public string date { get; set; }
        public Train  train{get; set;}
        public From from{get; set;}
        public To  to{ get; set; }
        public string otpr {get;set;}
        public string prib { get; set; }
        public string vputi { get; set; }
        public int l { get; set; }
        public int k { get; set; }
        public int p { get; set; }
        public int o { get; set; }
        public int c { get; set; }    
    }

    public class Train
    { 
        public string o {get; set;}
    }
    public class From
    {
        public string o { get; set; }
    }
    public class To
    {
        public string o { get; set; }
    }

}
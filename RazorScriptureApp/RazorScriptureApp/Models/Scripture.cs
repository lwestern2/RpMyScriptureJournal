using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RazorScriptureApp.Models
{
    public class Scripture
    {

        public int ID { get; set; }
        
        public string Book { get; set; }

        
        public int Chapter { get; set; }


        public int Verse { get; set; }
        public string Note { get; set; }
        [Display(Name = " Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public dynamic ViewBag { get; }

       

    }
}


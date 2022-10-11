using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGeography
{
    public class Brand
    {
        public int Id { get; set; }

        [StringLength(60)]
        public string Name { get; set; }

        [StringLength(100)]
        public string WebsiteUrl { get; set; }

        public int BrandGroupId { get; set; }

        //public virtual BrandGroup BrandGroup { get; set; }

        [Range(-90, 90)]
        public double Lat { get; set; }

        [Range(-180, 180)]
        public double Lng { get; set; }

        public Geometry Location { get; set; }
    }
}
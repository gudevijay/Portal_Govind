using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBPortal.Models
{
    public class InventoryModel
    {
        public string ServerID { get; set; }
        public string ServerIP { get; set; }
        public int ServerPort { get; set; }
        public string Name { get; set; }
        public string InstanceName { get; set; }
        public string SQLVersion { get; set; }
        public string Edition { get; set; }
        public string OSVesion { get; set; }
        public string ServeType { get; set; }
        public bool IsActive { get; set; }
        public string ServerEnv { get; set; }
        public string Description { get; set; }
        public string CommonName { get; set; }
        public string CMDB_Location { get; set; }
    }
}
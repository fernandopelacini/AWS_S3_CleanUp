using System;
using System.Collections.Generic;
using System.Text;

namespace AAWS.S3.CleanUp.Entities
{
    public class AWSEnvironment
    {
        public int AIR { get; set; }
        public string Region { get; set; }
        public string Name { get; set; }
        public string AccessKey { get; set; }
        public string SecretKey { get; set; }
        public string LogGroupNamePrefix { get; set; }
        public string[] S3Buckets { get; set; }
    }
}

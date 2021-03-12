using AAWS.S3.CleanUp.Entities;
using System;
using Amazon.S3;
using Amazon.S3.Model;
using System.Collections.Generic;
using System.Text;
using Amazon;
using Amazon.Runtime;

namespace AWS.S3.CleanUp.Entities
{
    public class S3Bucket
    {
        public static void CleanS3Buckets(AWSEnvironment environment)
        {
            Console.WriteLine("Process started...");
            var s3buckets = GetS3Buckets(environment, environment.S3Buckets);

            Console.WriteLine($"S3 buckets count: {s3buckets.Count }");

            if (s3buckets.Count > 0)
            { 

            }
        }

        private static List<S3Object> GetS3Buckets(AWSEnvironment environment, string[] s3Bucketsnames)
        {
            var result = new List<S3Object>();
            var config = new AmazonS3Config()
            {
                RegionEndpoint = RegionEndpoint.GetBySystemName(environment.Region)
            };

            var credentials = new BasicAWSCredentials(environment.AccessKey, environment.SecretKey);
            using (var client = new AmazonS3Client(credentials, config))
            {
                foreach (var bucket  in s3Bucketsnames)
                {
                    string marker = null;
                    Console.WriteLine($"Getting S3 objects from {bucket} bucket...");

                    do
                    {
                        var response = client.ListObjectsAsync(new ListObjectsRequest
                        {
                            BucketName = bucket,
                            Marker = marker
                        });
                        marker = response.NextMarker;
                        result.AddRange(response.S3Objects);
                    } while (!string.IsNullOrEmpty(marker));
                }
            }
            return result;
        }
    }
}

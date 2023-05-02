using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Core.Interface
{
    public interface IJobSeeker
    {
        string AddProfile(JobSeekerModel data);
        string DeleteProfile(int personId);
        string EditProfile(string personId, JobSeekerModel data);
        IEnumerable<JobSeekerModel> ViewProfile();
    }
}

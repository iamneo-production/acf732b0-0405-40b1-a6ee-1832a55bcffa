using System.Collections.Generic;
using dotnetapp.Models;

namespace dotnetapp.Core.Interface
{
    public interface IJobSeeker
    {
        string AddProfile(jobSeekerModel data);
        string DeleteProfile(string personId);
        string EditProfile(string personId, jobSeekerModel data);
        IEnumerable<jobSeekerModel> ViewProfile();
    }
}

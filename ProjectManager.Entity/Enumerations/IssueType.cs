using System.ComponentModel;

namespace ProjectManager.Entity.Enumerations
{
    public enum IssueType
    {
        Bug=0,
        Improvement=1,
        [Description("New feature")]
        NewFeature=2,
        Task=3,
        Test=4
    }
}

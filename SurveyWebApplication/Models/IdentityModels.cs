using Microsoft.AspNet.Identity.EntityFramework;

namespace SurveyWebApplication.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<SurveyWebApplication.Models.OptionType> OptionTypes { get; set; }

        public System.Data.Entity.DbSet<SurveyWebApplication.Models.Questionnaires> Questionnaires { get; set; }

        public System.Data.Entity.DbSet<SurveyWebApplication.Models.QuestionSet> QuestionSets { get; set; }
    }
}
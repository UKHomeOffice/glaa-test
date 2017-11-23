using GlaaCore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GlaaCore.Domain
{
    public static class GlaaContextInitializer
    {
        public static void Initialize(GlaaContext context)
        {
            context.Database.EnsureCreated();
            context.Licences.Add(new Licence
            {
                ApplicationId = "FULL-1234",
                OrganisationName = "My Full Organisation"
            });
            context.SaveChanges();
        }
    }
}

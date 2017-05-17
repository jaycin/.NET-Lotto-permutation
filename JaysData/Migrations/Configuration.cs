namespace JaysData.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JaysData.JaysContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(JaysData.JaysContext context)
        {

            IQueryable<Number> Numbers = context.Numbers.Distinct();
            if (Numbers == null || Numbers.Count() == 0)
            {
                for (int i = 1; i <= 49; i++)
                {
                    context.Numbers.Add(new Number() { Value = i });
                }
                context.SaveChanges();
                Numbers = context.Numbers;
            }
        }
    }
}

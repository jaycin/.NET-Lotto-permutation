using JaysData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace JaysSpace.Controllers
{

    public class JobController : ApiController
    {
        string returnString;
        // GET api/Job/Get
        public string Get()
        {
            PopulateGameData();
            return returnString;
        }
        public void PopulateGameData()
        {
            int numbers = 49;
            GenerateEntries(numbers);
        }

        public List<Entry> GenerateEntries(int numbers)
        {
            try
            {


                using (JaysContext context = new JaysContext())
                {
                    IQueryable<Number> Numbers = context.Numbers.Distinct();
                    tasks.Add(factory.StartNew(() => GetPermutations(Numbers, 6, 0, null, context)));
                    Task.WaitAll(tasks.ToArray());
                    return new List<Entry>();
                }
            }
            catch (Exception ex)
            {

                return new List<Entry>();
            }
        }
        static List<List<Number>> permutations = new List<List<Number>>();
        static TaskFactory factory = new TaskFactory();
        static List<Task> tasks = new List<Task>();
        static int permutationCount = 0;

        static void addEntry(Entry e, JaysContext c, List<Number> numbers)
        {
            try
            {
                permutationCount++;
                e.N1 = numbers.First();
                e.N2 = numbers.Skip(1).First();
                e.N3 = numbers.Skip(2).First();
                e.N4 = numbers.Skip(3).First();
                e.N5 = numbers.Skip(4).First();
                e.N6 = numbers.Skip(5).First();
                c.Entries.Add(e);
            }
            catch (Exception)
            {

            }

        }

        public static void GetPermutations(IEnumerable<Number> items, int size, int indent = 0, List<Number> data = null, JaysContext context = null)
        {
            int secondIndent = indent + 1;
            List<Number> args = new List<Number>();
            if (data == null)
                data = args;
            else
            {
                args.AddRange(data);

            }
            List<int> indexes = context.Entries.OrderByDescending(e => e.EntryId).Select(i => new List<int>() { i.N1.ID, i.N2.ID, i.N3.ID, i.N4.ID, i.N5.ID, i.N6.ID }).FirstOrDefault();
            if (indexes == null)
            {
                indexes = new List<int>() { 1, 2, 3, 4, 5, 6 };
            }
            else
            {
                if (indexes[5] != items.Count() - 5)
                {
                    indexes[5]++;
                }
                else if (indexes[4] != items.Count() - 4)
                {
                    indexes[4]++;
                }
                else if (indexes[3] != items.Count() - 3)
                {
                    indexes[3]++;
                }
                else if (indexes[2] != items.Count() - 2)
                {
                    indexes[2]++;
                }
                else if (indexes[1] != items.Count() - 1)
                {
                    indexes[1]++;
                }
                else
                {
                    indexes[0]++;
                }
            }


            for (int a = indexes.First(); a < items.Count(); a++)
            {
                for (int b = indexes.Skip(1).First(); b < items.Count() - 1; b++)
                {
                    for (int c = indexes.Skip(2).First(); c < items.Count() - 2; c++)
                    {
                        for (int d = indexes.Skip(3).First(); d < items.Count() - 3; d++)
                        {
                            for (int e = indexes.Skip(4).First(); e < items.Count() - 4; e++)
                            {
                                for (int f = indexes.Skip(5).First(); f < items.Count() - 5; f++)
                                {
                                    var t = items.Where(y => y.ID == a || y.ID == b || y.ID == c || y.ID == d
                                    || y.ID == e || y.ID == f).ToList();
                                    if (t != null)
                                    {
                                        if (t.Count == size)
                                        {
                                            List<Number> temp = new List<Number>();
                                            temp.AddRange(t);
                                            Entry tempE = new Entry();
                                            addEntry(tempE, context, temp);
                                            if (permutationCount >= 100)
                                            {
                                                context.SaveChanges();
                                                permutationCount = 0;
                                            }

                                        }
                                    }
                                } 
                            }
                        }
                    }
                    indexes = new List<int>() { 1, 2, 3, 4, 5, 6 };
                }
                

            }
        }

       





        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class Relations
    {
        public static List<Relation> RelationsList { get; set; }
        public static int Count { get; set; }

        // tämä pois?
        static Relations()
        {
            Relations.RelationsList = new List<Relation>();
            Relations.Count = 0;

        }
        //TODO id
        public static void AddRelation(Relation relation)
        {
            RelationsList.Add(relation);
            Count++;
        }

        public static Relation GetRelation(int id)
        {
            Relation relation = new Relation();
            foreach (var item in RelationsList)
            {
                if (item.RelationId == id) relation = item;
            }
            return relation;
        }

        //TODO poista myös relation
        public static bool RemoveRelation(int id)
        {
            foreach (var relation in RelationsList)
            {
                if (relation.RelationId == id)
                {
                    RelationsList.Remove(relation);
                    return true;
                }
            }
            return false;
        }
    }
}

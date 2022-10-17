namespace aula_03
{
    public abstract class Set
    {
        public abstract bool isIn(Set set);
        public virtual Set Union(Set set)
        {
            UnionSet unionSet = new UnionSet();
            unionSet.A = this;
            unionSet.B = set;
            return unionSet;
        }

        public virtual Set Intersect(Set set)
        {
            IntersectionSet interSet = new IntersectionSet();
            interSet.A = this;
            interSet.B = set;
            return interSet;
        }
    }

    public class EmptySet : Set
    {
        public override bool isIn(Set set) { return false; }
        
        public override bool Equals(object obj)
        {
            return obj is EmptySet;
        }
        
        public override Set Union(Set set) { return set; }

        public override Set Intersect(Set set) { return this; }
    }

    public class PairSet : Set
    {
        public PairSet(Set A, Set B)
        {
            this.A = A;
            this.B = B;
        }

        public Set A { get; set; }
        public Set B { get; set; }

        public override bool isIn(Set set)
        {
            return A.Equals(set) || B.Equals(set);
        }

        public override bool Equals(object obj)
        {
            if (obj is PairSet pair)
            {
                return (pair.A.Equals(this.A) && pair.B.Equals(this.B))
                || (pair.A.Equals(this.B) && pair.B.Equals(this.A))
                || (pair.A.Equals(pair.B) && (pair.A.Equals(this.A) || pair.A.Equals(this.B)));
            }
            return false;
        }
    }

    public class UnionSet : Set
    {
        public Set A { get; set; }
        public Set B { get; set; }

        public override bool isIn(Set set)
        {
            return A.isIn(set) || B.isIn(set);
        }
    }

    public class IntersectionSet : Set
    {
        public Set A { get; set; }
        public Set B { get; set; }

        public override bool isIn(Set set)
        {
            return A.isIn(set) && B.isIn(set);
        }
    }
}

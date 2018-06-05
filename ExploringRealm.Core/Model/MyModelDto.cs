using Realms;

namespace ExploringRealm.Core.Model
{
    internal class MyModelDto : RealmObject
    {
        public string Id { get; set; }
        public long SomeDateTicks { get; set; }
        public double SomeDouble { get; set; }
        public int SomeInt { get; set; }
    }
}
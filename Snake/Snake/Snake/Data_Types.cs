using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Snake
{
    class Data_Types
    {
    }

    struct COORD : IEnumerable
    {
        public Int16 first
        {
            get { return first; }
            set { first = value; }
        }
        public Int16 second
        {
            get { return second; }
            set { second = value; }
        }
        private bool addfirst;
        public void Add(Int16 value) //this makes me laugh really hard but it works!
        {
            if (addfirst)
                this.first = value;
            else
                this.second = value;
            addfirst = !addfirst;
        }
        public IEnumerator GetEnumerator(){return null;} //only here for compatibility reasons
    }
}

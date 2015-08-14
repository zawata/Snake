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
        private Int16 _first;
        public Int16 First
        {
            get { return _first; }
            set { _first = value; }
        }
        private Int16 _second;
        public Int16 Second
        {
            get { return _second; }
            set { _second = value; }
        }
        private bool addfirst;
        public void Add(Int16 value) //this makes me laugh really hard but it works!
        {
            if (addfirst)
                this.First = value;
            else
                this.Second = value;
            addfirst = !addfirst;
        }
        public IEnumerator GetEnumerator(){return null;} //only here for compatibility reasons
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace WayBook.DataModel
{
    public class WayBookBase<T> where T:new()
    {
        public Status status { get; set; }
        public T result { get; set; }
    }
}
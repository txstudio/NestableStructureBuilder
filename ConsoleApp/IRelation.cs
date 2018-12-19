using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    public interface IRelation
    {
        int No { get; set; }
        Nullable<int> ParentNo { get; set; }
    }
}

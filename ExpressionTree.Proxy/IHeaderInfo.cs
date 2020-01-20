using System.Collections.Generic;

namespace ExpressionTree.Proxy
{
    public interface IHeaderInfo
    {
        IEnumerable<string> PlanNumber { get; set; }
        IEnumerable<string> SmartFormCaseId { get; set; }
        IEnumerable<string> FileName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirPotr.FizzbuzzCode.Engine.Interface
{
    public class AirPotrException : ApplicationException
    {
        public AirPotrErrorCode ErrorCode { get; protected set; }
        public ErrorResult ErrorResult { get; protected set; }
        public AirPotrException(Exception innerException, AirPotrErrorCode code = AirPotrErrorCode.InvalidItemsInDictionary) : base("Object ,Invalid Items in the Dictionary", innerException)
        {
            ErrorCode = code;

        }
        public AirPotrException(ErrorResult errorResult, Exception innerException, AirPotrErrorCode code = AirPotrErrorCode.InvalidItemsInDictionary) : base(errorResult.ReasonPhrase, innerException)
        {
            ErrorCode = code;
            ErrorResult = errorResult;
        }
        public AirPotrException(ErrorResult errorResult, AirPotrErrorCode code = AirPotrErrorCode.InvalidItemsInDictionary) : base(errorResult.ReasonPhrase)
        {
            ErrorCode = code;
            ErrorResult = errorResult;
        }

    }
}

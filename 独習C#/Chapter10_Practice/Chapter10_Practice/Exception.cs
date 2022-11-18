using System;
using System.Runtime.Serialization;

namespace Chapter10_Practice
{
    /// <summary>
    /// Stackが満杯になっていることを通知するExceptionクラス
    /// </summary>
    class FullStackException : Exception
    {
        public FullStackException() : base() { }
        public FullStackException(string str) : base(str) { }
        public FullStackException(string str, Exception inner) : base(str, inner) { }
        protected FullStackException(SerializationInfo serializationInfo,
                                  StreamingContext streamingInfo)
                                  : base(serializationInfo, streamingInfo) { }
    }

    /// <summary>
    /// Stackが空になっていることを通知するExceptionクラス
    /// </summary>
    class EmptyStackException : Exception
    {
        public EmptyStackException() : base() { }
        public EmptyStackException(string str) : base(str) { }
        public EmptyStackException(string str, Exception inner) : base(str, inner) { }
        protected EmptyStackException(SerializationInfo serializationInfo,
                                  StreamingContext streamingInfo)
                                  : base(serializationInfo, streamingInfo) { }
    }
}

// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

/*=============================================================================
**
**
** Purpose: The exception class for class loading failures.
**
=============================================================================*/


using System;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace System
{
    [Serializable]
    [System.Runtime.CompilerServices.TypeForwardedFrom("mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089")]
    public class MissingFieldException : MissingMemberException, ISerializable
    {
        public MissingFieldException()
            : base(SR.Arg_MissingFieldException)
        {
            HResult = HResults.COR_E_MISSINGFIELD;
        }

        public MissingFieldException(string message)
            : base(message)
        {
            HResult = HResults.COR_E_MISSINGFIELD;
        }

        public MissingFieldException(string message, Exception inner)
            : base(message, inner)
        {
            HResult = HResults.COR_E_MISSINGFIELD;
        }

        protected MissingFieldException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string Message
        {
            get
            {
                if (ClassName == null)
                {
                    return base.Message;
                }
                else
                {
                    // do any desired fixups to classname here.
                    return SR.Format(SR.MissingField_Name, (Signature != null ? FormatSignature(Signature) + " " : "") + ClassName + "." + MemberName);
                }
            }
        }

        public MissingFieldException(string className, string fieldName)
        {
            ClassName = className;
            MemberName = fieldName;
        }

        // If ClassName != null, Message will construct on the fly using it
        // and the other variables. This allows customization of the
        // format depending on the language environment.
    }
}

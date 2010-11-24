// 
// UnaryOperatorExpression.cs
//  
// Author:
//       Mike Krüger <mkrueger@novell.com>
// 
// Copyright (c) 2009 Novell, Inc (http://www.novell.com)
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace ICSharpCode.NRefactory.CSharp
{
	public class UnaryOperatorExpression : DomNode
	{
		public const int Operator = 100;
		
		public override NodeType NodeType {
			get {
				return NodeType.Expression;
			}
		}

		public UnaryOperatorType UnaryOperatorType {
			get;
			set;
		}
		
		public DomNode Expression {
			get { return GetChildByRole (Roles.Expression) ?? DomNode.Null; }
		}
		
		public override S AcceptVisitor<T, S> (DomVisitor<T, S> visitor, T data)
		{
			return visitor.VisitUnaryOperatorExpression (this, data);
		}
	}
	
	public enum UnaryOperatorType
	{
		/// <summary>Logical not (!a)</summary>
		Not,
		/// <summary>Bitwise not (~a)</summary>
		BitNot,
		/// <summary>Unary minus (-a)</summary>
		Minus,
		/// <summary>Unary plus (+a)</summary>
		Plus,
		/// <summary>Pre increment (++a)</summary>
		Increment,
		/// <summary>Pre decrement (--a)</summary>
		Decrement,
		/// <summary>Post increment (a++)</summary>
		PostIncrement,
		/// <summary>Post decrement (a--)</summary>
		PostDecrement,
		/// <summary>Dereferencing (*a)</summary>
		Dereference,
		/// <summary>Get address (&a)</summary>
		AddressOf
	}
	
}

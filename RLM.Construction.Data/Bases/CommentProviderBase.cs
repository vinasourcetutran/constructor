﻿#region Using directives

using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;

using System.Diagnostics;
using RLM.Construction.Entities;
using RLM.Construction.Data;

#endregion

namespace RLM.Construction.Data.Bases
{	
	///<summary>
	/// This class is the base class for any <see cref="CommentProviderBase"/> implementation.
	/// It exposes CRUD methods as well as selecting on index, foreign keys and custom stored procedures.
	///</summary>
	public abstract partial class CommentProviderBase : CommentProviderBaseCore
	{
	} // end class
} // end namespace

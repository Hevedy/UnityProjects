﻿/*
===========================================================================
This code is part of the HevLib source code content in
HevLib by Hevedy <https://github.com/Hevedy/HevLib>
Mozilla Public License Version 2.0 (MPL-2.0)

Copyright (c) 2018-2019 Hevedy <https://github.com/Hevedy>

This Source Code Form is subject to the terms of the Mozilla Public
License, v. 2.0. If a copy of the MPL was not distributed with this
file, You can obtain one at http://mozilla.org/MPL/2.0/.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
===========================================================================
*/

/*
================================================
HEVProgram.cs
================================================
*/

using System;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Threading;
using System.IO;
using System.Reflection;
#if UNITY_EDITOR || UNITY_STANDALONE
using UnityEngine;
#else
#endif

namespace HEVLib {
	class HEVProgram {
		// You must set here you project default namespace if is different from build one otherwise expect crashes.
		// After define this make sure you add "HEVSAFE" to the compiler in order to unlock unsafe parts.
		private static readonly string CUSTOM_NAMESPACE = "GameThisNetCore"; //EDIT THIS

		public static readonly string Dir = Environment.CurrentDirectory;
		public static readonly string Name = Assembly.GetExecutingAssembly().GetName().Name;
		public static readonly string NameFull = Assembly.GetExecutingAssembly().GetName().FullName;
		// System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Namespace; / typeof( HEVProgram ).Namespace;
		public static readonly string Namespace = HEVText.Validate( CUSTOM_NAMESPACE ) ? CUSTOM_NAMESPACE : Name;
		public static readonly string DirFile = Assembly.GetEntryAssembly().Location;
		public static readonly string DirDocuments = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments );
		public static readonly bool IsDLL = HEVIO.FileIsLibrary(DirFile);

		private static double Timestamp = CurrentTime();

		/// <summary>Validate a string or a list of strings, make sure aren't empty, invalid or null.</summary>
		public static bool FileString( out string _String ) {
			byte[] bytes = null;
			bool status = false;
			(bytes, status) = HEVIO.FileBytesRead( DirFile );
			if ( !status ) { _String = null; return false; }
			_String =  HEVText.ByteArrayToString( bytes );
			return true;
		}

		/// <summary>Return current program MD5 key.</summary>
		public static string FileHashMD5() {
			string code = "";
			if ( !FileString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}

		/// <summary>Return current program SHA1 key.</summary>
		public static string FileHashSHA1() {
			string code = "";
			if ( !FileString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}

		/// <summary>Return current program SHA256 key.</summary>
		public static string FileHashSHA256() {
			string code = "";
			if ( !FileString( out code ) ) { return code; }
			return HEVText.HashMD5( code );
		}

		/// <summary>Return current program milliseconds.</summary>
		public static double CurrentTime() {
			double time = DateTime.Now.Millisecond;
			Timestamp = time;
			return time;
		}

		/// <summary>Return current program elapsed milliseconds since the last CurrentTime() call.</summary>
		public static double LastTime() {
			return Timestamp;
		}
	}
}

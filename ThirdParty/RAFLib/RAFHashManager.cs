using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

using ItzWarty;

namespace RAFLib
{
    /// <summary>
    /// Manages the handling of hashes for RAF Strings, which is calculated in an unknown
    /// matter at the moment.
    /// </summary>
    public static class RAFHashManager
    {
        public static UInt32 GetHash(string s)
        {
            //if (hashes == null) Init();
            //Console.WriteLine("Calc hash of: " + s);
            /* Ported from documented code in RAF Documentation:
             * 
	         *      const char* pStr = 0;
	         *      unsigned long hash = 0;
	         *      unsigned long temp = 0;
             *
	         *      for(pStr = pName; *pStr; ++pStr)
	         *      {
		     *          hash = (hash << 4) + tolower(*pStr);
		     *          if (0 != (temp = hash & 0xf0000000)) 
		     *          {
			 *              hash = hash ^ (temp >> 24);
			 *              hash = hash ^ temp;
		     *          }
	         *      }
	         *      return hash;
             */
            UInt32 hash = 0;
            UInt32 temp = 0;
            for(int i = 0; i < s.Length; i++)
            {
                hash = (hash << 4) + s.ToLower()[i];
                if(0 != (temp = (hash & 0xF0000000)))
                {
                    hash = hash ^ (temp >> 24);
                    hash = hash ^ temp;
                }
            }
            //Console.WriteLine("!");
            
            //Console.WriteLine("Hash expected: " + hashes[s]);
            //Console.WriteLine("Hash Calculated: " + hash);
            return hash;
        }
    }
}

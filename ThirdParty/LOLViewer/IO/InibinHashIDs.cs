﻿
/*
LOLViewer
Copyright 2011-2012 James Lammlein 

 

This file is part of LOLViewer.

LOLViewer is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
any later version.

LOLViewer is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with LOLViewer.  If not, see <http://www.gnu.org/licenses/>.

*/


//
// Stores the known hash IDs for character *.inibin files.
//
// Based on the work of ItzWarty and Engberg.
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LOLViewer.IO
{
    public enum InibinHashID : long
    {
        SKIN_ONE_NAME = 0L, // Unknown.  Based off of directory name?
        SKIN_ONE_SKN = 769344815L,
        SKIN_ONE_TEXTURE = -1654783749L,
        SKIN_ONE_SKL = 1895303501L,

        SKIN_TWO_NAME = 1742464788L,
        SKIN_TWO_SKN = 306040338L,
        SKIN_TWO_TEXTURE = 664710616L,
        SKIN_TWO_SKL = 599757744L,

        SKIN_THREE_NAME = 1652845395L,
        SKIN_THREE_SKN = 525951185L,
        SKIN_THREE_TEXTURE = -88577063L,
        SKIN_THREE_SKL = -719956497L,

        SKIN_FOUR_NAME = 1563226002L,
        SKIN_FOUR_SKN = 745862032L,
        SKIN_FOUR_TEXTURE = -841864742L,
        SKIN_FOUR_SKL = -2039670738L,

        SKIN_FIVE_NAME = 1473606609L,
        SKIN_FIVE_SKN = 965772879L,
        SKIN_FIVE_TEXTURE = -1595152421L,
        SKIN_FIVE_SKL = 935582317L,

        SKIN_SIX_NAME = 1383987216L,
        SKIN_SIX_SKN = 1185683726L,
        SKIN_SIX_TEXTURE = 1946527196L,
        SKIN_SIX_SKL = -384131924L,

        SKIN_SEVEN_NAME = 1294367823L,
        SKIN_SEVEN_SKN = 1405594573L,
        SKIN_SEVEN_TEXTURE = 1193239517L,
        SKIN_SEVEN_SKL = -1703846165L,

        SKIN_EIGHT_NAME = 1204748430L,
        SKIN_EIGHT_SKN = 1625505420L,
        SKIN_EIGHT_TEXTURE = 439951838L,
        SKIN_EIGHT_SKL = 1271406890L,

        // Keys from original code.
        // LOLModel Viewer does not use them.  So, I have never confirmed their correctness.
        // However, the originals are here if anyone needs to extend this class.
        PROP_ID = 2921476548L,
        PROP_HP = 742042233L,
        PROP_HPL = 3306821199L,
        PROP_MANA = 742370228L,
        PROP_MANAL = 1003217290L,
        PROP_MOVE = 1081768566L,
        PROP_ARMOR = 2599053023L,
        PROP_ARMORL = 1608827366L,
        PROP_MR = 1395891205L,
        PROP_MRL = 4032178956L,
        PROP_HP5 = 4128291318L,
        PROP_HP5L = 3062102972L,
        PROP_MP5 = 619143803L,
        PROP_MP5L = 1248483905L,
        PROP_BASE_ASPD_MINUS = 2191293239L,
        PROP_ASPDL = 770205030L,
        PROP_AD = 1880118880L,
        PROP_ADL = 1139868982L,
        PROP_RANGE = 1387461685L,
    }
}

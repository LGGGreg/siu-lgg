using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Be.Windows.Forms;

namespace RAFManager
{
    /// <summary>
    /// Implements the IByteProvider interface
    /// Used with the HexBox control
    /// </summary>
    public class MemoryByteProvider:IByteProvider
    {
        byte[] data = null;
        /// <summary>
        /// Instantiates a MemoryByteProvider which
        /// will feed the given data to a HexBox
        /// </summary>
        /// <param name="data"></param>
        public MemoryByteProvider(byte[] data)
        {
            this.data = data;
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        byte IByteProvider.ReadByte(long index)
        {
            return data[index];
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        void IByteProvider.WriteByte(long index, byte value)
        {
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        void IByteProvider.InsertBytes(long index, byte[] bs)
        {
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        void IByteProvider.DeleteBytes(long index, long length)
        {
        }

        long IByteProvider.Length
        {
            get { return this.data.Length; }
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        event EventHandler IByteProvider.LengthChanged
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Returns false, since we don't permit editing
        /// </summary>
        bool IByteProvider.HasChanges()
        {
            return false;
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        void IByteProvider.ApplyChanges()
        {
        }

        /// <summary>
        /// Not implemented intentionally
        /// </summary>
        event EventHandler IByteProvider.Changed
        {
            add { }
            remove { }
        }

        /// <summary>
        /// Returns false - Editing isn't supported
        /// </summary>
        bool IByteProvider.SupportsWriteByte()
        {
            return false;
        }

        /// <summary>
        /// Returns false - Editing isn't supported
        /// </summary>
        bool IByteProvider.SupportsInsertBytes()
        {
            return false;
        }

        /// <summary>
        /// Returns false - Editing isn't supported
        /// </summary>
        bool IByteProvider.SupportsDeleteBytes()
        {
            return false;
        }
    }
}

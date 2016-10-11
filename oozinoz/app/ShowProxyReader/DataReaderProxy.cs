using System;
using System.Data;

namespace DataLayer
{
	/// <summary>
	/// This class strictly forwards every call to a subject object. To
	/// intercept any specific call, create a subclass.
	/// </summary>
	public class DataReaderProxy : IDataReader
	{
        private IDataReader _subject;
        /// <summary>
        /// Create a proxy for the given subject.
        /// </summary>
        /// <param name="subject">The real reader to proxy for</param>
        public DataReaderProxy(IDataReader subject) 
        {
            _subject = subject;
        }
        // properties for IDataRecord
        public virtual int FieldCount
        {
            get
            {
                return _subject.FieldCount;
            }
        }
        public virtual object this [string name]
        {
            get
            {
                return _subject[name];
            }
        }
        public virtual object this [int index]
        {
            get
            {
                return _subject[index];
            }
        }
        // properties for IDataReader
        public virtual int Depth
        {
            get
            {
                return _subject.Depth;
            }
        }
        public virtual bool IsClosed
        {
            get
            {
                return _subject.IsClosed;
            }
        }
        // methods for IDataRecord
        public virtual bool GetBoolean(int i) 
        {
            return _subject.GetBoolean(i);
        }
        public virtual byte GetByte(int i) 
        {
            return _subject.GetByte(i);
        }
        public virtual long GetBytes(
            int i,
            long fieldoffset,
            byte[] buffer,
            int bufferoffset,
            int length
            ) 
        {
            return _subject.GetBytes(i, fieldoffset, buffer, bufferoffset, length);
        }
        public virtual char GetChar(int i) 
        {
            return _subject.GetChar(i);
        }
        public virtual long GetChars(
            int i,
            long fieldoffset,
            char[] buffer,
            int bufferoffset,
            int length
            ) 
        {
            return _subject.GetChars(i, fieldoffset, buffer, bufferoffset, length);
        }
        public virtual IDataReader GetData(int i) 
        {
            return _subject.GetData(i);
        }
        public virtual string GetDataTypeName(int i) 
        {
            return _subject.GetDataTypeName(i);
        }
        public virtual DateTime GetDateTime(int i) 
        {
            return _subject.GetDateTime(i);
        }
        public virtual decimal GetDecimal(int i) 
        {
            return _subject.GetDecimal(i);
        }
        public virtual double GetDouble(int i) 
        {
            return _subject.GetDouble(i);
        }
        public virtual Type GetFieldType(int i) 
        {
            return _subject.GetFieldType(i);
        }
        public virtual float GetFloat(int i) 
        {
            return _subject.GetFloat(i);
        }
        public virtual Guid GetGuid(int i) 
        {
            return _subject.GetGuid(i);
        }
        public virtual short GetInt16(int i) 
        {
            return _subject.GetInt16(i);
        }
        public virtual int GetInt32(int i) 
        {
            return _subject.GetInt32(i);
        }
        public virtual long GetInt64(int i) 
        {
            return _subject.GetInt64(i);
        }
        public virtual string GetName(int i) 
        {
            return _subject.GetName(i);
        }
        public virtual int GetOrdinal(string name) 
        {
            return _subject.GetOrdinal(name);
        }
        public virtual string GetString(int i) 
        {
            return _subject.GetString(i);
        }
        public virtual object GetValue(int i) 
        {
            return _subject.GetValue(i);
        }
        public virtual int GetValues(object [] values) 
        {
            return _subject.GetValues(values);
        }
        public virtual bool IsDBNull(int i)
        {
            return _subject.IsDBNull(i);
        }
        // methods for IDataReader
        public virtual int RecordsAffected
        {
            get
            {
                return _subject.RecordsAffected;
            }
        }
        public virtual void Close()
        {
            _subject.Close();
        }
        public virtual DataTable GetSchemaTable()
        {
            return _subject.GetSchemaTable();
        }
        public virtual bool NextResult()
        {
            return _subject.NextResult();
        }
        public virtual bool Read()
        {
            return _subject.Read();
        }
        // methods for IDisposable
        public virtual void Dispose()
        {
            _subject.Dispose();
        }
	}
}

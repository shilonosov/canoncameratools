using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Collections;

namespace Source
{
    public class EnumValueCollection : KeyedCollection<uint, EnumValue>
    {
        protected override uint GetKeyForItem(EnumValue anEnum2)
        {
            return anEnum2.Value;
        }

        public EnumValue AtIndex(int anIndex)
        {
            return Items[anIndex];
        }

        public EnumValue AtKey(Enum aKey)
        {
            return this[Convert.ToInt32(aKey)];
        }

        public EnumValue GetWithRelatedIndex(EnumValue anInitialiValue, int anIndex)
        {
            return AtIndex(IndexOf(anInitialiValue) + anIndex);
        }

        public int GetIndexDifferenceBeetween(EnumValue aEnumValue1, EnumValue aEnumValue2)
        {
            return IndexOf(aEnumValue1) - IndexOf(aEnumValue2);
        }
    }

    public class EnumValue
    {
        private readonly uint _type;
        protected uint _value;
        protected string _displayString;


        public uint Value
        {
            get { return _value; }
        }

        public string DisplayString
        {
            get { return _displayString; }
        }

        public uint Type
        {
            get { return _type; }
        }

        public EnumValue()
        {
        }

        public EnumValue(uint aValue, string aDisplayString, uint type)
        {
            _value = aValue;
            _displayString = aDisplayString;
            _type = type;
        }

        public static EnumValueCollection GetListFrom(ICamera aCamera, uint aType, EnumValueCollection aCollection)
        {
            EnumValueCollection result = new EnumValueCollection();
            uint[] rawValues = aCamera.GetAvailableValues(aType);

            ArrayList unsupported = new ArrayList();

            for (int i = 0; i < rawValues.Length; i++)
            {
                uint enumValue = rawValues[i];
                if (enumValue != 0)
                {
                    try
                    {
                        result.Add(aCollection[enumValue]);
                    }
                    catch
                    {
                        unsupported.Add(enumValue);
                    }
                }
            }

            return result;
        }

        public override string ToString()
        {
            return _displayString;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((EnumValue)obj);
        }

        public bool Equals(EnumValue obj)
        {
            return Equals(this, obj);
        }

        public static bool Equals(EnumValue obj1, EnumValue obj2)
        {
            if ((obj1 != null) && (obj2 != null))
            {
                return obj1._value == obj2._value;
            }
            else
            {
                return (obj1 == null) && (obj2 == null);
            }
        }


        public override int GetHashCode()
        {
            return Convert.ToInt32(_value);
        }

        public void ApplyTo(ICamera aCamera)
        {
            aCamera.SetProperty(_type, _value);
        }
    }
}
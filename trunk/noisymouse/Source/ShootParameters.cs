using System;
using System.Collections;
using System.Collections.ObjectModel;
using EDSDKLib;

namespace Source
{
    public interface IShootParameters
    {
        string DisplayString { get; }

        IsoSpeed Iso { get; }
        Aperture Aperture { get; }
        Exposal Exposal { get; set; }
        ShootParameters Copy();
        void ApplyTo(ICamera aCamera);
        void Add(EnumValue aParameter);
    }

    public class ShootParametersCollection: KeyedCollection<uint, EnumValue>
    {
        public void ForEach(Action<EnumValue> anAction)
        {
            foreach(EnumValue parameter in this)
            {
                anAction(parameter);
            }
        }

        public void AddAll(IEnumerable aParameters)
        {
            foreach (EnumValue parameter in aParameters)
            {
                if (parameter != null)
                {
                    Add(parameter);
                }
            }
        }

        protected override uint GetKeyForItem(EnumValue item)
        {
            return item.Type;
        }

        public void Replace(uint aKey, EnumValue aValue)
        {
            SetItem(IndexOf(this[aKey]), aValue);
        }

        public override bool Equals(object obj)
        {
            ShootParametersCollection collection = obj as ShootParametersCollection;
            if ((collection != null) && (collection.Count == Count))
            {
                for (int i = 0; i < Count; i++)
                {
                    if (!collection.Items[i].Equals(Items[i]))
                    {
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }
        
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public class ShootParameters : IShootParameters
    {
        private readonly ShootParametersCollection _parameters = new ShootParametersCollection();

        public string DisplayString
        {
            get
            {
                if (_parameters.Count > 0)
                {
                    const string separator = ", ";
                    string result = string.Empty;

                    _parameters.ForEach(
                        parameter => result += string.Format("{0}{1}", parameter.DisplayString, separator));

                    return result.Remove(result.Length - separator.Length, separator.Length);
                }
                return string.Empty;
            }
        }

        public IsoSpeed Iso
        {
            get { return (IsoSpeed) _parameters[EDSDK.PropID_ISOSpeed]; }
        }

        public Aperture Aperture
        {
            get { return (Aperture) _parameters[EDSDK.PropID_Av]; }
            set { _parameters.Replace(EDSDK.PropID_Av, value); }
        }

        public Exposal Exposal
        {
            get { return (Exposal) _parameters[EDSDK.PropID_Tv]; }
            set { _parameters.Replace(EDSDK.PropID_Tv, value); }
        }

        public ShootParameters(IsoSpeedEnum aIsoSpeedEnum, ApertureEnum aApertureEnum, ExposalEnum aExposalEnum)
            : this(IsoSpeed.With(aIsoSpeedEnum), Source.Aperture.With(aApertureEnum), Source.Exposal.With(aExposalEnum))
        {
        }

        public ShootParameters(params EnumValue[] anAdditionalParameters)
        {
            _parameters.AddAll(anAdditionalParameters);
        }

        public ShootParameters(ShootParametersCollection aCollection)
        {
            _parameters.AddAll(aCollection);
        }

        public ShootParameters Copy()
        {
            return new ShootParameters(_parameters);
        }

        public void ApplyTo(ICamera aCamera)
        {
            _parameters.ForEach(parameter=>parameter.ApplyTo(aCamera));
        }

        public void Add(EnumValue aParameter)
        {
            _parameters.Add(aParameter);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ShootParameters) obj);
        }

        public bool Equals(ShootParameters obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return _parameters.Equals(obj._parameters);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return _parameters.GetHashCode();
            }
        }

        public override string ToString()
        {
            return DisplayString;
        }
    }
}

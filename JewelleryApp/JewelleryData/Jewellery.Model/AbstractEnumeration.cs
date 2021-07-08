using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jewellery.Enities
{
    public abstract class AbstractEnumeration : IComparable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayText { get; set; }
        public override string ToString() => Name;

        protected AbstractEnumeration(int id, string name, string displayText)
        {
            Id = id;
            Name = name;
            DisplayText = displayText;
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as AbstractEnumeration;

            if (otherValue == null)
                return false;

            var typeMatches = GetType() == obj.GetType();
            var valueMatches = Id.Equals(otherValue.Id);

            return typeMatches && valueMatches;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            return Id.CompareTo(((AbstractEnumeration)other).Id);
        }

        public static bool operator ==(AbstractEnumeration left, AbstractEnumeration right)
        {
            if (ReferenceEquals(left, null))
            {
                return ReferenceEquals(right, null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(AbstractEnumeration left, AbstractEnumeration right)
        {
            return !(left == right);
        }

        public static bool operator <(AbstractEnumeration left, AbstractEnumeration right)
        {
            return ReferenceEquals(left, null) ? !ReferenceEquals(right, null) : left.CompareTo(right) < 0;
        }

        public static bool operator <=(AbstractEnumeration left, AbstractEnumeration right)
        {
            return ReferenceEquals(left, null) || left.CompareTo(right) <= 0;
        }

        public static bool operator >(AbstractEnumeration left, AbstractEnumeration right)
        {
            return !ReferenceEquals(left, null) && left.CompareTo(right) > 0;
        }

        public static bool operator >=(AbstractEnumeration left, AbstractEnumeration right)
        {
            return ReferenceEquals(left, null) ? ReferenceEquals(right, null) : left.CompareTo(right) >= 0;
        }
    }
}

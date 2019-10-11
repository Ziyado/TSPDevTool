using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TSPDevTools.Model;

namespace TSPDevTool.UI
{
    public class IdComparer : IEqualityComparer<Skill>
    {
        public int GetHashCode(Skill skill)
        {
            if (skill == null)
            {
                return 0;
            }
            return skill.ID.GetHashCode();
        }

        public bool Equals(Skill x1, Skill x2)
        {
            if (object.ReferenceEquals(x1, x2))
            {
                return true;
            }
            if (object.ReferenceEquals(x1, null) ||
                object.ReferenceEquals(x2, null))
            {
                return false;
            }
            return x1.ID == x2.ID;
        }
    }
}
// Comparer for Tracks 
public class IdComparerTrack : IEqualityComparer<Track>
{
    public int GetHashCode(Track track)
    {
        if (track == null)
        {
            return 0;
        }
        return track.ID.GetHashCode();
    }

    public bool Equals(Track x1, Track x2)
    {
        if (object.ReferenceEquals(x1, x2))
        {
            return true;
        }
        if (object.ReferenceEquals(x1, null) ||
            object.ReferenceEquals(x2, null))
        {
            return false;
        }
        return x1.ID == x2.ID;
    }
}
// comparer for Subs


public class IdComparerSubs : IEqualityComparer<Subsidary>
{
    public int GetHashCode(Subsidary sub)
    {
        if (sub == null)
        {
            return 0;
        }
        return sub.ID.GetHashCode();
    }

    public bool Equals(Subsidary x1, Subsidary x2)
    {
        if (object.ReferenceEquals(x1, x2))
        {
            return true;
        }
        if (object.ReferenceEquals(x1, null) ||
            object.ReferenceEquals(x2, null))
        {
            return false;
        }
        return x1.ID == x2.ID;
    }
}
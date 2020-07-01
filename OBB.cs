using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Praedonum
{
    public class OBB
    {
       
        private float m_orientation; 
        private Vector2[] m_axis;
        private Vector2 m_extents;
        private Vector2 m_center;

        public OBB(float rotation, Vector2 center, Vector2 extents)
        {
            m_orientation = rotation;
            m_axis = new Vector2[2];
            m_center = center;
            m_extents = extents;
        }

        public float Radius(Vector2 axis)
        {
            return Extents.X * Math.Abs(Vector2.Dot(axis, Axis[0]))
                    + Extents.Y * Math.Abs(Vector2.Dot(axis, Axis[1]));
        }

        public void CalculateAxis()
        {
            float c = (float)Math.Cos(m_orientation);
            float s = (float)Math.Sin(m_orientation);

            m_axis[0] = new Vector2(c, s);
            m_axis[1] = new Vector2(-s, c);
        }

        private bool SeparatedOnAxis(OBB obb, Vector2 axis)
        {
            float r = Math.Abs(Vector2.Dot(Center - obb.Center, axis));
            return Radius(axis) + obb.Radius(axis) < r;
        }

        public bool TestOBBOBB(OBB obb)
        {
            if (SeparatedOnAxis(obb, Axis[0]))
                return false;
            if (SeparatedOnAxis(obb, Axis[1]))
                return false;
            if (SeparatedOnAxis(obb, obb.Axis[0]))
                return false;
            if (SeparatedOnAxis(obb, obb.Axis[1]))
                return false;

            return true;
        }

        public Vector2[] GetDebugPoints()
        {
            Vector2[] v = new Vector2[9];
            v[0] = Center;
            v[1] = TopLeft;
            v[2] = TopRight;
            v[3] = BottomRight;
            v[4] = BottomLeft;
            v[5] = TopLeft + (TopRight - TopLeft) * 0.5f;
            v[6] = TopRight + (BottomRight - TopRight) * 0.5f;
            v[7] = BottomLeft + (BottomRight - BottomLeft) * 0.5f;
            v[8] = TopLeft + (BottomLeft - TopLeft) * 0.5f;

            return v;
        }

        #region Properties


        public Vector2 TopLeft
        {
            get { return Center - Axis[0]*Extents.X - Axis[1]*Extents.Y; }
        }

        public Vector2 TopRight
        {
            get { return Center + Axis[0] * Extents.X - Axis[1] * Extents.Y; }
        }

        public Vector2 BottomLeft
        {
            get { return Center - Axis[0] * Extents.X + Axis[1] * Extents.Y; }
        }

        public Vector2 BottomRight
        {
            get { return Center + Axis[0] * Extents.X + Axis[1] * Extents.Y; }
        }

        public float Orientation
        {
            get { return m_orientation; }
            set { m_orientation = value; }
        }

        public Vector2[] Axis
        {
            get { return m_axis; }
            set { m_axis = value; }
        }

        public Vector2 Extents
        {
            get { return m_extents; }
            set { m_extents = value; }
        }

        public Vector2 Center
        {
            get { return m_center; }
            set { m_center = value; }
        }
        #endregion

    }
}

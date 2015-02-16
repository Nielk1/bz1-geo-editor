using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BZ1GeoEditor
{
    public class GeoHeader
    {
        // note it is very important that this flags remain unchanged
        public const long _GOURAUD_SHADED = 0x001;
        public const long _TILED_BITMAP = 0x002;
        public const long _TEXTURE_MAP = 0x004;
        public const long _PARALLEL = 0x008;
        public const long _TRUE_PERSPECTIVE = 0x010;
        public const long _WIRE_FRAME = 0x020;
        public const long _TRANSPARENT_PIXELS = 0x040;
        public const long _ONE_THIRD_TRANSLUCENT_PIXELS = 0x080;

        // Special Cases and specials flags
        public const long _PROJECT_POLYGON_ONLY = 0x100;

        // Composit
        public const long _ALPHA_BLEND = (_TRANSPARENT_PIXELS | _ONE_THIRD_TRANSLUCENT_PIXELS);
        public const long _TWO_THIRD_TRANSLUCENT_PIXELS = (_WIRE_FRAME | _ONE_THIRD_TRANSLUCENT_PIXELS);
        public const long _FLAT_PERSPECTIVE_MAP = (0xff & (~(_PARALLEL | _GOURAUD_SHADED | _TILED_BITMAP)));
        public const long _FLAT_TILED_PERSPECTIVE_MAP = (0xff & (~(_PARALLEL | _GOURAUD_SHADED)));
        public const long _HALLOW_WIRE_FRAME = (0xff & (~(_PARALLEL | _TRUE_PERSPECTIVE | _TEXTURE_MAP)));

        public long Tag; // '.GEO' File tag
        public long cksum; // File checksum
        public char[] Name; // Object name
        public long NumVerts; // Number of vertices in object
        public long NumPolys; // Number of faces in object
        public long Flags; // Object Flags

        public bool Flags_GOURAUD_SHADED
        {
            get { return (Flags & _GOURAUD_SHADED) == _GOURAUD_SHADED; }
            set { Flags = value ? (long)(Flags | _GOURAUD_SHADED) : (long)(Flags & ~_GOURAUD_SHADED); }
        }

        public bool Flags_TILED_BITMAP
        {
            get { return (Flags & _TILED_BITMAP) == _TILED_BITMAP; }
            set { Flags = value ? (long)(Flags | _TILED_BITMAP) : (long)(Flags & ~_TILED_BITMAP); }
        }

        public bool Flags_TEXTURE_MAP
        {
            get { return (Flags & _TEXTURE_MAP) == _TEXTURE_MAP; }
            set { Flags = value ? (long)(Flags | _TEXTURE_MAP) : (long)(Flags & ~_TEXTURE_MAP); }
        }

        public bool Flags_PARALLEL
        {
            get { return (Flags & _PARALLEL) == _PARALLEL; }
            set { Flags = value ? (long)(Flags | _PARALLEL) : (long)(Flags & ~_PARALLEL); }
        }

        public bool Flags_TRUE_PERSPECTIVE
        {
            get { return (Flags & _TRUE_PERSPECTIVE) == _TRUE_PERSPECTIVE; }
            set { Flags = value ? (long)(Flags | _TRUE_PERSPECTIVE) : (long)(Flags & ~_TRUE_PERSPECTIVE); }
        }

        public bool Flags_WIRE_FRAME
        {
            get { return (Flags & _WIRE_FRAME) == _WIRE_FRAME; }
            set { Flags = value ? (long)(Flags | _WIRE_FRAME) : (long)(Flags & ~_WIRE_FRAME); }
        }

        public bool Flags_TRANSPARENT_PIXELS
        {
            get { return (Flags & _TRANSPARENT_PIXELS) == _TRANSPARENT_PIXELS; }
            set { Flags = value ? (long)(Flags | _TRANSPARENT_PIXELS) : (long)(Flags & ~_TRANSPARENT_PIXELS); }
        }

        public bool Flags_ONE_THIRD_TRANSLUCENT_PIXELS
        {
            get { return (Flags & _ONE_THIRD_TRANSLUCENT_PIXELS) == _ONE_THIRD_TRANSLUCENT_PIXELS; }
            set { Flags = value ? (long)(Flags | _ONE_THIRD_TRANSLUCENT_PIXELS) : (long)(Flags & ~_ONE_THIRD_TRANSLUCENT_PIXELS); }
        }

        public bool Flags_PROJECT_POLYGON_ONLY
        {
            get { return (Flags & _PROJECT_POLYGON_ONLY) == _PROJECT_POLYGON_ONLY; }
            set { Flags = value ? (long)(Flags | _PROJECT_POLYGON_ONLY) : (long)(Flags & ~_PROJECT_POLYGON_ONLY); }
        }

        public bool Flags_Composit_ALPHA_BLEND
        {
            get { return (Flags & _ALPHA_BLEND) == _ALPHA_BLEND; }
            set { Flags = value ? (long)(Flags | _ALPHA_BLEND) : (long)(Flags & ~_ALPHA_BLEND); }
        }

        public bool Flags_Composit_TWO_THIRD_TRANSLUCENT_PIXELS
        {
            get { return (Flags & _TWO_THIRD_TRANSLUCENT_PIXELS) == _TWO_THIRD_TRANSLUCENT_PIXELS; }
            set { Flags = value ? (long)(Flags | _TWO_THIRD_TRANSLUCENT_PIXELS) : (long)(Flags & ~_TWO_THIRD_TRANSLUCENT_PIXELS); }
        }

        public bool Flags_Composit_FLAT_PERSPECTIVE_MAP
        {
            get { return (Flags & _FLAT_PERSPECTIVE_MAP) == _FLAT_PERSPECTIVE_MAP; }
            set { Flags = value ? (long)(Flags | _FLAT_PERSPECTIVE_MAP) : (long)(Flags & ~_FLAT_PERSPECTIVE_MAP); }
        }

        public bool Flags_Composit_FLAT_TILED_PERSPECTIVE_MAP
        {
            get { return (Flags & _FLAT_TILED_PERSPECTIVE_MAP) == _FLAT_TILED_PERSPECTIVE_MAP; }
            set { Flags = value ? (long)(Flags | _FLAT_TILED_PERSPECTIVE_MAP) : (long)(Flags & ~_FLAT_TILED_PERSPECTIVE_MAP); }
        }

        public bool Flags_Composit_HALLOW_WIRE_FRAME
        {
            get { return (Flags & _HALLOW_WIRE_FRAME) == _HALLOW_WIRE_FRAME; }
            set { Flags = value ? (long)(Flags | _HALLOW_WIRE_FRAME) : (long)(Flags & ~_HALLOW_WIRE_FRAME); }
        }

        public string Name_STR
        {
            get { return new string(Name).TrimEnd('\0'); }
            set
            {
                Array.Clear(Name, 0, Name.Length);
                value.Substring(0, Math.Min(value.Length, 16)).ToArray().CopyTo(Name, 0);
            }
        }

        public GeoHeader()
        {
            Tag = 0x2E47454F;
            Name = new char[16];
        }

        public GeoHeader(BinaryReader reader)
        {
            Tag = Utility.ReadInt32(reader);
            cksum = Utility.ReadInt32(reader);
            Name = reader.ReadChars(16);
            NumVerts = Utility.ReadInt32(reader);
            NumPolys = Utility.ReadInt32(reader);
            Flags = Utility.ReadInt32(reader);
        }

        internal void Save(BinaryWriter writer)
        {
            Utility.Write(writer, Tag);
            Utility.Write(writer, cksum);
            writer.Write(Name, 0, 16);
            Utility.Write(writer, NumVerts);
            Utility.Write(writer, NumPolys);
            Utility.Write(writer, Flags);
        }
    };

    public struct Vector3D
    {
        public float x; // x, y, and z components of a 3D vector
        public float y;
        public float z;

        public Vector3D(BinaryReader reader)
        {
            x = Utility.ReadSingle(reader);
            y = Utility.ReadSingle(reader);
            z = Utility.ReadSingle(reader);
        }

        public void Save(BinaryWriter writer)
        {
            Utility.Write(writer, x);
            Utility.Write(writer, y);
            Utility.Write(writer, z);
        }
    };

    public struct ColorRGB
    {
        public byte r, g, b; // Red/Green/Blue values of color

        public ColorRGB(BinaryReader reader)
        {
            r = reader.ReadByte();
            g = reader.ReadByte();
            b = reader.ReadByte();
        }

        public void Save(BinaryWriter writer)
        {
            writer.Write(r);
            writer.Write(g);
            writer.Write(b);
        }
    };

    public struct GeoCollisionInfo
    {
        public Vector3D GeoCenter; // Geometric Center of Object
        public float SphereRadius; // Bounding Sphere Radius
        public float BoxHalfHeightX; // Bounding Box X Axis
        public float BoxHalfHeightY; // Bounding Box Y Axis
        public float BoxHalfHeightZ; // Bounding Box Z Axis
    };

    public struct FaceNode
    {
        public long VertexId; // Index into vertex list
        public long VertexNormalId; // Index into vertex normal list
        public float u, v; // Textmap u, v coordinates

        public FaceNode(BinaryReader reader)
        {
            VertexId = Utility.ReadInt32(reader);
            VertexNormalId = Utility.ReadInt32(reader);
            u = Utility.ReadSingle(reader);
            v = Utility.ReadSingle(reader);
        }

        public void Save(BinaryWriter writer)
        {
            Utility.Write(writer, VertexId);
            Utility.Write(writer, VertexNormalId);
            Utility.Write(writer, u);
            Utility.Write(writer, v);
        }
    };

    public struct SurfacePlane
    {
        public Vector3D SurfaceNormal; // Unit vector of surface normal
        public float Distance; // Shortest distance from the origin to a point
                               // on the plane perpendicular to the surface normal

        public SurfacePlane(BinaryReader reader)
        {
            SurfaceNormal = new Vector3D(reader);
            Distance = reader.ReadSingle();
        }

        public void Save(BinaryWriter writer)
        {
            SurfaceNormal.Save(writer);
            Utility.Write(writer, Distance);
        }
    };

    public class Face
    {
        // values in Face ShadeType
        public const byte GEO_WIREFRAME = 1;
        public const byte GEO_SOLID_WIREFRAME = 2;
        public const byte GEO_CONSTANT_SHADED = 3;
        public const byte GEO_FLAT_SHADED = 4;
        public const byte GEO_GOUROUD_SHADED = 5;

        // values in Face TextureType
        public const byte GEO_TRUE_PERSPECTIVE = 0x01;
        public const byte GEO_TILED_TEXTUREMAP = 0x02;
        public const byte GEO_XPARENT_TEXTMAP = 0x04;

        // values in Face XluscentType
        public const byte GEO_NO_XLUSCENCY = 0;
        public const byte GEO_ONE_THIRD_XLUSCENCY = 1;
        public const byte GEO_TWO_THIRD_XLUSCENCY = 2;

        // values in Face TreeBranch
        public const bool BACK = false;
        public const bool FRONT = true;

        public long Index; // Index of this face
        public long VertexCount; // Number of vertices in face
        public ColorRGB Color; // Color of the face
        public SurfacePlane Plane; // Surface normal
        public float PolyArea; // Surface area of the polygon
        public byte ShadeType; // Poly shade type (constant, flat, gouroud)
        public byte TextureType; // Poly texturemap type (afine, true perspective, tiled, xparent)
        public byte XluscentType; // Transluscency type (0%, 33%, 66%)
        public char[] TextureName; // pointer to a texture to be applied to the
        public long ParentFace; // Index into face list of BSP parent
        public bool TreeBranch; // Face is front/back branch in BSP tree
        public FaceNode[] Wireframe; // List of vertices in face

        public bool TextureType_TRUE_PERSPECTIVE
        {
            get { return (TextureType & GEO_TRUE_PERSPECTIVE) == GEO_TRUE_PERSPECTIVE; }
            set { TextureType = value ? (byte)(TextureType | GEO_TRUE_PERSPECTIVE) : (byte)(TextureType & ~GEO_TRUE_PERSPECTIVE); }
        }

        public bool TextureType_TILED_TEXTUREMAP
        {
            get { return (TextureType & GEO_TILED_TEXTUREMAP) == GEO_TILED_TEXTUREMAP; }
            set { TextureType = value ? (byte)(TextureType | GEO_TILED_TEXTUREMAP) : (byte)(TextureType & ~GEO_TILED_TEXTUREMAP); }
        }

        public bool TextureType_XPARENT_TEXTMAP
        {
            get { return (TextureType & GEO_XPARENT_TEXTMAP) == GEO_XPARENT_TEXTMAP; }
            set { TextureType = value ? (byte)(TextureType | GEO_XPARENT_TEXTMAP) : (byte)(TextureType & ~GEO_XPARENT_TEXTMAP); }
        }

        public string TextureName_STR {
            get { return new string(TextureName).TrimEnd('\0'); }
            set
            {
                Array.Clear(TextureName, 0, TextureName.Length);
                value.Substring(0, Math.Min(value.Length, 13)).ToArray().CopyTo(TextureName, 0);
            }
        }

        public static bool TryRead(BinaryReader reader, out Face fc)
        {
            fc = null;

            try
            {
                if (reader.BaseStream.Length - reader.BaseStream.Position <= 0) return false;

                Face tmp = new Face();

                tmp.Index = Utility.ReadInt32(reader);
                tmp.VertexCount = Utility.ReadInt32(reader);
                tmp.Color = new ColorRGB(reader);
                tmp.Plane = new SurfacePlane(reader);
                tmp.PolyArea = Utility.ReadSingle(reader);
                tmp.ShadeType = reader.ReadByte();
                tmp.TextureType = reader.ReadByte();
                tmp.XluscentType = reader.ReadByte();
                tmp.TextureName = reader.ReadChars(13);
                tmp.ParentFace = Utility.ReadInt32(reader);
                tmp.TreeBranch = Utility.ReadInt32(reader) == 1;
                tmp.Wireframe = new FaceNode[tmp.VertexCount];
                for (int x = 0; x < tmp.Wireframe.Length; x++)
                {
                    tmp.Wireframe[x] = new FaceNode(reader);
                }

                fc = tmp;
                return true;
            }
            catch (EndOfStreamException) { }


            return false;
        }

        public void Save(BinaryWriter writer)
        {
            Utility.Write(writer, Index);
            Utility.Write(writer, VertexCount);
            Color.Save(writer);
            Plane.Save(writer);
            Utility.Write(writer, PolyArea);
            writer.Write(ShadeType);
            writer.Write(TextureType);
            writer.Write(XluscentType);
            writer.Write(TextureName, 0, 13);
            Utility.Write(writer, ParentFace);
            Utility.Write(writer, TreeBranch ? 1 : 0);
            for (int x = 0; x < Wireframe.Length; x++)
            {
                Wireframe[x].Save(writer);
            }
        }
    };

    public class Geo
    {
        public GeoHeader header;
        public Vector3D[] vecs;
        public Vector3D[] vecnorms;
        public List<Face> faces;

        public Geo(BinaryReader reader)
        {
            header = new GeoHeader(reader);

            vecs = new Vector3D[header.NumVerts];
            vecnorms = new Vector3D[header.NumVerts];
            faces = new List<Face>();

            for (int x = 0; x < vecs.Length; x++)
            {
                vecs[x] = new Vector3D(reader);
            }

            for (int x = 0; x < vecnorms.Length; x++)
            {
                vecnorms[x] = new Vector3D(reader);
            }

            Face fc = null;
            while(Face.TryRead(reader, out fc))
            {
                faces.Add(fc);
            }
        }

        public void Save(string path)
        {
            using (FileStream stream = File.Open(path, FileMode.Create))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    header.Save(writer);

                    for (int x = 0; x < vecs.Length; x++)
                    {
                        vecs[x].Save(writer);
                    }

                    for (int x = 0; x < vecnorms.Length; x++)
                    {
                        vecnorms[x].Save(writer);
                    }

                    faces.ForEach(fc =>
                    {
                        fc.Save(writer);
                    });
                }
            }
        }
    }

    class Utility
    {
        public static float ReadSingle(BinaryReader reader)
        {
            byte[] arr = reader.ReadBytes(4);
            if (arr.Length == 0) throw new EndOfStreamException();
            if (BitConverter.IsLittleEndian) arr.Reverse();
            return BitConverter.ToSingle(arr, 0);
        }

        public static Int64 ReadInt32(BinaryReader reader)
        {
            byte[] arr = reader.ReadBytes(4);
            if (arr.Length == 0) throw new EndOfStreamException();
            if (BitConverter.IsLittleEndian) arr.Reverse();
            return BitConverter.ToInt32(arr, 0);
        }

        public static void Write(BinaryWriter writer, float val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian) arr.Reverse();
            writer.Write(arr, 0, 4);
        }

        public static void Write(BinaryWriter writer, Int64 val)
        {
            byte[] arr = BitConverter.GetBytes(val);
            if (BitConverter.IsLittleEndian) arr.Reverse();
            writer.Write(arr, 0, 4);
        }
    }
}

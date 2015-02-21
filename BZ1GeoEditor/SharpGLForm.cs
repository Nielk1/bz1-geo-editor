using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpGL;
using System.IO;
using System.Drawing.Imaging;

namespace BZ1GeoEditor
{
    /// <summary>
    /// The main form class.
    /// </summary>
    public partial class SharpGLForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharpGLForm"/> class.
        /// </summary>
        public SharpGLForm()
        {
            InitializeComponent();

            using(Graphics g = Graphics.FromImage(DummyTexture))
            {
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, DummyTexture.Width, DummyTexture.Height);
            }

            pbPallet.SizeMode = PictureBoxSizeMode.StretchImage;
            //pbPallet.ha

            if (!File.Exists("information.txt")) File.WriteAllText("information.txt", "Please note that given the high level of access this tool gives to GEO format headers and face data, arbitrary changes to GEO files are likely to cause crashes when loaded by the game. Do test all changes thoroughly and share what information you learn with the community.");
            txtInformation.Text = File.ReadAllText("information.txt");

            if (!File.Exists("notes.txt")) File.Create("notes.txt").Close();
            txtNotes.Text = File.ReadAllText("notes.txt");
            notesLoaded = true;
        }

        /// <summary>
        /// Handles the OpenGLDraw event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RenderEventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLDraw(object sender, RenderEventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Clear the color and depth buffer.
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //  Load the identity matrix.
            gl.LoadIdentity();

            //  Use the 'look at' helper function to position and aim the camera.
            //gl.LookAt(0, 0, -10, 0, 0, 0, 0, 1, 0);
            gl.LookAt(0, 0, -zoom, 0, 0, 0, 0, 1, 0);

            // Rotate around X axis;
            gl.Rotate(-pitch, 1.0f, 0.0f, 0.0f);

            //  Rotate around the Y axis.
            gl.Rotate(rotation, 0.0f, 1.0f, 0.0f);

            //gl.Translate(-transX, transY, 0);

            //if (geo != null)
            //{

            //  Draw a coloured pyramid.
            //gl.Begin(OpenGL.GL_TRIANGLES);

            if (geo != null)
            {
                float maxArea = curRenderStyle == RenderStyle.FaceArea ? geo.faces.Max(dr => dr.PolyArea) : 0.0f;

                foreach (Face face in geo.faces)
                {
                    bool HighlightColor = false;
                    //Color HighlightBrightness = Color.White;
                    if (tcTabs.SelectedTab == tpFaces && lstFaces.SelectedItem != null)
                    {
                        foreach (FaceListWrapper selectedItem in lstFaces.SelectedItems)
                        {
                            if (selectedItem.Value.Index == face.Index)
                            {
                                HighlightColor = true;
                                break;
                            }
                        }
                    }

                    if (tcTabs.SelectedTab == tpUV && lstFacesUV.SelectedItem != null)
                    {
                        foreach (FaceListWrapper selectedItem in lstFacesUV.SelectedItems)
                        {
                            if (selectedItem.Value.Index == face.Index)
                            {
                                HighlightColor = true;
                                break;
                            }
                        }
                    }

                    bool color = false;
                    bool frontback = false;
                    bool areacolor = false;

                    float treeRatio = 0.5f;

                    if (checkerBitmaps.ContainsKey(face.TextureName_STR))
                    {
                        gl.BindTexture(OpenGL.GL_TEXTURE_2D, checkerBitmaps[face.TextureName_STR].textureID);
                    }
                    else
                    {
                        Console.WriteLine("Failed to Bind Texture \"{0}\"", face.TextureName_STR);
                    }

                    gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);
                    gl.PolygonMode(OpenGL.GL_BACK, OpenGL.GL_LINE);

                    switch (curRenderStyle)
                    {
                        case RenderStyle.Special_Back_Front:
                            frontback = true;
                            break;
                        case RenderStyle.FaceArea:
                            areacolor = true;
                            break;
                        case RenderStyle.Wire:
                            gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_LINE);
                            break;
                        case RenderStyle.Solid:
                            break;
                        case RenderStyle.Color:
                            color = true;
                            break;
                        case RenderStyle.Checker:
                            break;
                        case RenderStyle.Texture:
                            break;
                    }

                    if (frontback)
                    {
                        //treeRatio = ((FaceBranchDict[face.Index] * 1.0f / FaceBranchMax) + 0.5f) / 2;
                        treeRatio = (FaceBranchDict[face.Index] + FaceBranchMax) / (FaceBranchMax * 2.0f);
                    }

                    if (HighlightColor)
                    {
                        gl.PolygonMode(OpenGL.GL_FRONT, OpenGL.GL_FILL);
                        //gl.Disable(OpenGL.GL_LIGHTING);

                    }

                    bool RENDER_FACE = true;
                    bool RENDER_WIRE = false;
                    bool RENDER_FLAT = false;
                    if (face.ShadeType == Face.GEO_WIREFRAME) { RENDER_FACE = false; RENDER_WIRE = true; }
                    if (face.ShadeType == Face.GEO_SOLID_WIREFRAME) { RENDER_WIRE = true; }
                    if (face.ShadeType == Face.GEO_CONSTANT_SHADED) { }
                    if (face.ShadeType == Face.GEO_FLAT_SHADED) { RENDER_FLAT = true; }
                    if (face.ShadeType == Face.GEO_GOUROUD_SHADED) { }

                    byte alpha = 0xff;
                    if (face.XluscentType == Face.GEO_ONE_THIRD_XLUSCENCY) alpha = 0xaa;
                    if (face.XluscentType == Face.GEO_TWO_THIRD_XLUSCENCY) alpha = 0x55;

                    if (RENDER_FACE)
                    {
                        if (RENDER_FLAT)
                        {
                            gl.ShadeModel(OpenGL.GL_FLAT);
                        }

                        gl.Begin(OpenGL.GL_TRIANGLES);

                        int off1 = 0;
                        int off2 = 1;

                        Vector3D v0 = geo.vecs[face.Wireframe[off1].VertexId];
                        Vector3D n0 = /*geo.vecnorms.Length > face.Wireframe[0] ?*/ geo.vecnorms[face.Wireframe[off1].VertexNormalId];// : DEFNORM;
                        float u10 = face.Wireframe[off1].u;//rootBlock.uvs.Count > face.Wireframe[0] ? rootBlock.uvs[face.Wireframe[0]] : DEFUV;
                        float u20 = face.Wireframe[off1].v;//rootBlock.uvs.Count > face.Wireframe[0] ? rootBlock.uvs[face.Wireframe[0]] : DEFUV;
                        //MSHModel.VertIndex state0 = rootBlock.vertToState[face.Wireframe[1]];

                        Vector3D v1 = geo.vecs[face.Wireframe[off2].VertexId];
                        Vector3D n1 = /*geo.vecnorms.Count > face.Wireframe[1] ?*/ geo.vecnorms[face.Wireframe[off2].VertexNormalId];// : DEFNORM;
                        float u11 = face.Wireframe[off2].u;//rootBlock.uvs.Count > face.Wireframe[1] ? rootBlock.uvs[face.Wireframe[1]] : DEFUV;
                        float u21 = face.Wireframe[off2].v;//rootBlock.uvs.Count > face.Wireframe[1] ? rootBlock.uvs[face.Wireframe[1]] : DEFUV;
                        //MSHModel.VertIndex state1 = rootBlock.vertToState[face.Wireframe[1]];

                        Color? area = null;
                        if (areacolor) { area = Lerp(Color.White, Color.Red, face.PolyArea / maxArea); }

                        Color? branch = null;
                        if (frontback) { branch = Lerp(Color.Red, Color.White, treeRatio); }

                        for (int vertId = 2; vertId < face.Wireframe.Length; vertId++)
                        {
                            Vector3D v2 = geo.vecs[face.Wireframe[vertId].VertexId];
                            Vector3D n2 = /*geo.vecnorms.Count > face.Wireframe[vertId] ?*/ geo.vecnorms[face.Wireframe[vertId].VertexNormalId];// : DEFNORM;
                            float u12 = face.Wireframe[vertId].u;//rootBlock.uvs.Count > face.Wireframe[vertId] ? rootBlock.uvs[face.Wireframe[vertId]];// : DEFUV;
                            float u22 = face.Wireframe[vertId].v;//rootBlock.uvs.Count > face.Wireframe[vertId] ? rootBlock.uvs[face.Wireframe[vertId]];// : DEFUV;
                            //MSHModel.VertIndex state2 = rootBlock.vertToState[face.Wireframe[vertId]];

                            if (area.HasValue) { gl.Color(area.Value.R, area.Value.G, area.Value.B, alpha); }
                            //else if (frontback) { if (face.TreeBranch == Face.FRONT) { gl.Color((byte)0xff, (byte)0x0, (byte)0x0, alpha); } else { gl.Color((byte)0x0, (byte)0x0, (byte)0xff, alpha); } }
                            else if (branch.HasValue) { gl.Color(branch.Value.R, branch.Value.G, branch.Value.B, alpha); }
                            else if (color) { gl.Color(face.Color.r, face.Color.g, face.Color.b, alpha); } else { gl.Color((byte)0xee, (byte)0xee, (byte)0xee, alpha); }
                            gl.TexCoord(u10, u20);
                            gl.Normal(n0.x, n0.y, -n0.z);
                            gl.Vertex(v0.x, v0.y, -v0.z);

                            if (area.HasValue) { gl.Color(area.Value.R, area.Value.G, area.Value.B, alpha); }
                            //else if (frontback) { if (face.TreeBranch == Face.FRONT) { gl.Color((byte)0xff, (byte)0x0, (byte)0x0, alpha); } else { gl.Color((byte)0x0, (byte)0x0, (byte)0xff, alpha); } }
                            else if (branch.HasValue) { gl.Color(branch.Value.R, branch.Value.G, branch.Value.B, alpha); }
                            else if (color) { gl.Color(face.Color.r, face.Color.g, face.Color.b, alpha); } else { gl.Color((byte)0xee, (byte)0xee, (byte)0xee, alpha); }
                            gl.TexCoord(u11, u21);
                            gl.Normal(n1.x, n1.y, -n1.z);
                            gl.Vertex(v1.x, v1.y, -v1.z);

                            if (area.HasValue) { gl.Color(area.Value.R, area.Value.G, area.Value.B, alpha); }
                            //else if (frontback) { if (face.TreeBranch == Face.FRONT) { gl.Color((byte)0xff, (byte)0x0, (byte)0x0, alpha); } else { gl.Color((byte)0x0, (byte)0x0, (byte)0xff, alpha); } }
                            else if (branch.HasValue) { gl.Color(branch.Value.R, branch.Value.G, branch.Value.B, alpha); }
                            else if (color) { gl.Color(face.Color.r, face.Color.g, face.Color.b, alpha); } else { gl.Color((byte)0xee, (byte)0xee, (byte)0xee, alpha); }
                            gl.TexCoord(u12, u22);
                            gl.Normal(n2.x, n2.y, -n2.z);
                            gl.Vertex(v2.x, v2.y, -v2.z);

                            v1 = v2;
                            n1 = n2;
                            u11 = u12;
                            u21 = u22;
                            //state1 = state2;
                        }

                        gl.End();

                        if (RENDER_FLAT)
                        {
                            gl.ShadeModel(OpenGL.GL_SMOOTH);
                        }

                        //if (HighlightColor)
                        //{
                        //    gl.Enable(OpenGL.GL_LIGHTING);
                        //}
                    }

                    if (RENDER_WIRE)
                    {
                        gl.Begin(OpenGL.GL_LINES);
                        Vector3D lastV = geo.vecs[face.Wireframe.Last().VertexId];
                        Vector3D lastN = geo.vecnorms[face.Wireframe.Last().VertexNormalId];
                        float lastUU = face.Wireframe.Last().u;
                        float lastUV = face.Wireframe.Last().v;
                        for (int vertId = 0; vertId < face.Wireframe.Length; vertId++)
                        {
                            Vector3D curV = geo.vecs[face.Wireframe[vertId].VertexId];
                            Vector3D curN = geo.vecnorms[face.Wireframe[vertId].VertexNormalId];
                            float curUU = face.Wireframe[vertId].u;
                            float curUV = face.Wireframe[vertId].v;

                            gl.Color(face.Color.r, face.Color.g, face.Color.b);
                            gl.TexCoord(lastUU, lastUV);
                            gl.Normal(lastN.x, lastN.y, -lastN.z);
                            gl.Vertex(lastV.x, lastV.y, -lastV.z);
                            gl.TexCoord(curUU, curUV);
                            gl.Normal(curN.x, curN.y, -curN.z);
                            gl.Vertex(curV.x, curV.y, -curV.z);

                            lastV = curV;
                            lastN = curN;
                            lastUU = curUU;
                            lastUV = curUV;
                        }
                        gl.End();
                    }

                    if (HighlightColor)
                    {
                        gl.LineWidth(5.0f);
                        gl.Disable(OpenGL.GL_TEXTURE_2D);
                        gl.Disable(OpenGL.GL_LIGHTING);
                        gl.Begin(OpenGL.GL_LINES);
                        Vector3D last = geo.vecs[face.Wireframe.Last().VertexId];
                        for (int vertId = 0; vertId < face.Wireframe.Length; vertId++)
                        {
                            Vector3D cur = geo.vecs[face.Wireframe[vertId].VertexId];

                            gl.Color((byte)0xff, (byte)0x0, (byte)0x0);
                            gl.Vertex(last.x, last.y, -last.z);
                            gl.Vertex(cur.x, cur.y, -cur.z);

                            last = cur;
                        }
                        gl.End();
                        gl.LineWidth(1.0f);
                        gl.Enable(OpenGL.GL_TEXTURE_2D);
                        gl.Enable(OpenGL.GL_LIGHTING);
                    }
                }
            }

            //gl.End();
        }



        /// <summary>
        /// Handles the OpenGLInitialized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_OpenGLInitialized(object sender, EventArgs e)
        {
            //  TODO: Initialise OpenGL here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the clear color.
            gl.ClearColor(0.5f, 0.5f, 0.5f, 1.0f);

            gl.Enable(OpenGL.GL_COLOR_MATERIAL);
            gl.Enable(OpenGL.GL_TEXTURE_2D);
            gl.Enable(OpenGL.GL_LIGHTING);

            // alpha vertex colors
            gl.Enable(OpenGL.GL_BLEND);
            gl.BlendFunc(OpenGL.GL_SRC_ALPHA, OpenGL.GL_ONE_MINUS_SRC_ALPHA);

            // 1 sided faces
            //gl.Enable(OpenGL.GL_CULL_FACE);

            gl.Enable(OpenGL.GL_LIGHT0);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, new float[] { 0.4f, 0.4f, 0.4f });

            float[] light_position = { 0, -1, 0, 0 };
            float[] light_brightness = { 1, 1, 1, 1 };
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light_position);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light_brightness);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light_brightness);
        }

        /// <summary>
        /// Handles the Resized event of the openGLControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void openGLControl_Resized(object sender, EventArgs e)
        {
            //  TODO: Set the projection matrix here.

            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            //  Set the projection matrix.
            gl.MatrixMode(OpenGL.GL_PROJECTION);

            //  Load the identity.
            gl.LoadIdentity();

            //  Create a perspective transformation.
            gl.Perspective(60.0f, (double)openGLControl.Width / (double)openGLControl.Height, 0.01, 1000.0);

            //  Set the modelview matrix.
            gl.MatrixMode(OpenGL.GL_MODELVIEW);
        }

        /// <summary>
        /// The current rotation.
        /// </summary>
        private float rotation = 0.0f;
        private float pitch = 0.0f;

        private float transX = 0.0f;
        private float transY = 0.0f;

        private double zoom = 10;

        private Geo geo;

        private bool MouseLeftActive = false;
        private bool MouseRightActive = false;
        private int oldMouseX;
        private int oldMouseY;

        private Random rand = new Random();

        private List<string> textureNames = new List<string>();
        private Dictionary<string, TextureDataMap> checkerBitmaps = new Dictionary<string, TextureDataMap>();
        //private Dictionary<string, TextureDataMap> textureBitmaps = new Dictionary<string, TextureDataMap>();

        Bitmap DummyTexture = new Bitmap(256, 256);

        uint[] DummyTextureID = new uint[1];

        enum RenderStyle
        {
            Special_Back_Front,
            FaceArea,
            Wire,
            Solid,
            Color,
            Checker,
            Texture
        };

        RenderStyle curRenderStyle = RenderStyle.Texture;

        AboutBox1 aboutDialog = new AboutBox1();

        bool DisableEvents = false;

        bool notesLoaded = false;

        Dictionary<long, int> FaceBranchDict = new Dictionary<long, int>();
        int FaceBranchMax = 0;

        private string path;

        private class TextureDataMap
        {
            public Bitmap checker;

            public uint[] _textureID;

            public uint textureID { get { return _textureID[0]; } }

            public MapFile map;
            public Color[] pallet;

            public TextureDataMap() { _textureID = new uint[1]; }
        }

        private class FaceListWrapper
        {
            private Face dr;
            private string lineItem;

            public Face Value { get { return dr; } }

            public FaceListWrapper(Face dr, string lineItem)
            {
                this.dr = dr;
                this.lineItem = lineItem;
            }
            public bool AddLine(int pos)
            {
                StringBuilder sb = new StringBuilder(lineItem);
                if (sb[pos] == ' ')
                {
                    sb[pos] = '│';
                    lineItem = sb.ToString();
                    return true;
                }
                else if (sb[pos] == '└')
                {
                    sb[pos] = '├';
                    lineItem = sb.ToString();
                    return true;
                }
                return false;
            }
            public override string ToString()
            {
                return lineItem;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (!e.Cancel)
            {
                saveFileDialog1.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                saveFileDialog1.FileName = Path.GetFileName(openFileDialog1.FileName);

                saveFileDialog2.InitialDirectory = Path.GetDirectoryName(openFileDialog1.FileName);
                saveFileDialog2.FileName = Path.ChangeExtension(Path.GetFileName(openFileDialog1.FileName), "obj");

                processFile(openFileDialog1.FileName);
            }
        }

        private void processFile(string filename)
        {
            path = Path.GetDirectoryName(filename);
            using (FileStream _FileStream = new System.IO.FileStream(filename, System.IO.FileMode.Open, System.IO.FileAccess.Read))
            {
                using (BinaryReader _BinaryReader = new System.IO.BinaryReader(_FileStream))
                {
                    geo = new Geo(_BinaryReader);

                    //OpenGL gl = openGLControl.OpenGL;
                    //textures.ToList().ForEach(dr => gl.DeleteTextures(1, dr.Value._textureID));
                    //textures.Clear();

                    if (geo != null)
                    {
                        DisableEvents = true;

                        OpenGL gl = openGLControl.OpenGL;
                        checkerBitmaps.ToList().ForEach(dr => gl.DeleteTextures(1, dr.Value._textureID));
                        checkerBitmaps.Clear();

                        //textureBitmaps.ToList().ForEach(dr => gl.DeleteTextures(1, dr.Value._textureID));
                        //textureBitmaps.Clear();

                        float holdX = 0;
                        float holdY = 0;
                        float holdZ = 0;
                        for (int x = 0; x < geo.vecs.Length; x++)
                        {
                            holdX = Math.Max(holdX, Math.Abs(geo.vecs[x].x));
                            holdY = Math.Max(holdY, Math.Abs(geo.vecs[x].y));
                            holdZ = Math.Max(holdZ, Math.Abs(geo.vecs[x].z));
                        }

                        zoom = 2.0f * Math.Sqrt((holdX * holdX) + (holdY * holdY) + (holdZ * holdZ));

                        //if (DummyTexture == null)
                        //{
                        //    DummyTexture = new TextureData() { checker = new Bitmap(256, 256) };
                        //    //gl.BindTexture(OpenGL.GL_TEXTURE_2D, DummyTexture.textureID);
                        //}

                        textureNames.Clear();
                        geo.faces.ForEach(face =>
                        {
                            if (!textureNames.Contains(face.TextureName_STR)) textureNames.Add(face.TextureName_STR);
                        });

                        loadMAPToolStripMenuItem.DropDownItems.Clear();
                        clearMAPToolStripMenuItem.DropDownItems.Clear();
                        loadACTToolStripMenuItem.DropDownItems.Clear();
                        clearACTToolStripMenuItem.DropDownItems.Clear();
                        cbTexture.Items.Clear();
                        lbTextures.Items.Clear();
                        bool first = true;
                        textureNames.ForEach(name =>
                        {
                            AddTexture(name, !first);

                            first = false;
                        });

                        lbTextures.Enabled = true;
                        btnAddTexture.Enabled = true;

                        if (cbRender.SelectedIndex == -1)
                        {
                            cbRender.SelectedItem = "Texture";
                            curRenderStyle = RenderStyle.Texture;
                        }
                        cbRender.Enabled = true;

                        txtName.Text = geo.header.Name_STR;
                        txtName.Enabled = true;

                        FaceBranchDict.Clear();
                        FaceBranchMax = 0;

                        lstFaces.Items.Clear();
                        lstFacesUV.Items.Clear();
                        lstFaces.BeginUpdate();
                        lstFacesUV.BeginUpdate();
                        Stack<long> FaceIDs = new Stack<long>();
                        FaceIDs.Push(-1);
                        int index = 0;
                        geo.faces.ForEach(dr =>
                        {
                            while (FaceIDs.Peek() != dr.ParentFace) FaceIDs.Pop();

                            if (dr.ParentFace == -1)
                            {
                                FaceBranchDict[dr.Index] = 0;
                            }
                            else
                            {
                                int BranchVal = FaceBranchDict.ContainsKey(FaceIDs.Peek()) ? FaceBranchDict[FaceIDs.Peek()] : 0;
                                if (dr.TreeBranch) { FaceBranchDict[dr.Index] = BranchVal + 1; } else { FaceBranchDict[dr.Index] = BranchVal - 1; }
                            }

                            FaceIDs.Push(dr.Index);
                            int Depth = FaceIDs.Count() - 2;
                            string lineItem = string.Empty;
                            if (Depth > 1) lineItem += new string(' ', Depth - 1);
                            if (Depth > 0) lineItem += '└';
                            switch (dr.VertexCount)
                            {
                                case 3: lineItem += "TRI"; break;
                                case 4: lineItem += "QUAD"; break;
                                case 5: lineItem += "PENT"; break;
                                case 6: lineItem += "HEX"; break;
                                default: lineItem += dr.VertexCount.ToString(); break;
                            }
                            lineItem += string.Format(" ({0})", dr.Index);

                            if (lstFaces.Items.Count > 0)
                            {
                                if(Depth > 0)
                                {
                                    int LineHunt = index - 1;
                                    while (LineHunt > -1)
                                    {
                                        FaceListWrapper item = (FaceListWrapper)lstFaces.Items[LineHunt];
                                        if (item.AddLine(Depth - 1))
                                        {
                                            lstFaces.Items[LineHunt] = item;
                                            LineHunt--;
                                        }else{
                                            LineHunt = -1;
                                        }
                                    }
                                }
                            }
                            lstFaces.Items.Add(new FaceListWrapper(dr, lineItem));

                            index++;
                        });

                        lstFacesUV.Items.AddRange(lstFaces.Items);

                        lstFaces.EndUpdate();
                        lstFacesUV.EndUpdate();
                        lstFaces.Enabled = true;
                        lstFacesUV.Enabled = true;

                        FaceBranchMax = FaceBranchDict.Max(dr => Math.Abs(dr.Value));

                        /*{
                            treeView1.Nodes.Clear();
                            Dictionary<long, Tuple<TreeNode, Face>> FaceNodeList = new Dictionary<long, Tuple<TreeNode, Face>>();
                            geo.faces.ForEach(dr =>
                            {
                                TreeNode node = new TreeNode(dr.Index.ToString());
                                FaceNodeList.Add(dr.Index, new Tuple<TreeNode, Face>(node, dr));
                            });
                            FaceNodeList.ToList().ForEach(dr =>
                            {
                                if (dr.Value.Item2.ParentFace == -1)
                                {
                                    treeView1.Nodes.Add(dr.Value.Item1);
                                }
                                else
                                {
                                    FaceNodeList[dr.Value.Item2.ParentFace].Item1.Nodes.Add(dr.Value.Item1);
                                }
                            });
                            treeView1.ExpandAll();
                            treeView1.Enabled = true;
                        }*/

                        UpdateOGLTextureData();

                        DisableEvents = false;

                        setHeaderCheckboxes();
                    }
                }
            }
        }

        private void OpenMap_Click(object sender, EventArgs e)
        {
            openFileDialog2.FileName = ((ToolStripItem)sender).Text + ".map";
            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog2.FileName))
                {
                    TextureDataMap dat = checkerBitmaps[((ToolStripItem)sender).Text];
                    dat.map = MapFile.FromFile(openFileDialog2.FileName);

                    UpdateOGLTextureData();
                }
            }
        }

        private void ClearMap_Click(object sender, EventArgs e)
        {
            TextureDataMap dat = checkerBitmaps[((ToolStripItem)sender).Text];
            dat.map = null;

            UpdateOGLTextureData();
        }

        private void OpenAct_Click(object sender, EventArgs e)
        {
            openFileDialog3.FileName = "objects.act";
            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(openFileDialog3.FileName))
                {
                    TextureDataMap dat = checkerBitmaps[((ToolStripItem)sender).Text];
                    dat.pallet = MapFile.PalletFromFile(openFileDialog3.FileName);

                    UpdateOGLTextureData();
                }
            }
        }

        private void ClearAct_Click(object sender, EventArgs e)
        {
            TextureDataMap dat = checkerBitmaps[((ToolStripItem)sender).Text];
            dat.pallet = null;

            UpdateOGLTextureData();
        }

        private void UpdateOGLTextureData()
        {
            OpenGL gl = openGLControl.OpenGL;

            //checkerBitmaps.ToList().ForEach(dr =>
            //{
            //    //dr.Value.checker.UnlockBits();
            //    gl.DeleteTextures(1, dr.Value._textureID);
            //});

            checkerBitmaps.ToList().ForEach(dr =>
            {
                gl.GenTextures(1, dr.Value._textureID);

                Bitmap datBitmap = null;
                switch((string)cbRender.SelectedItem)
                {
                    //case "Wire":
                    //    break;
                    //case "Solid":
                    //    break;
                    //case "Color":
                    //    break;
                    case "Checker":
                        datBitmap = (Bitmap)dr.Value.checker.Clone();
                        break;
                    case "Texture":
                        if (dr.Value.map != null)
                        {
                            if (dr.Value.pallet != null && dr.Value.map.IsPalletized)
                            {
                                datBitmap = dr.Value.map.GetBitmap(dr.Value.pallet);
                            }
                            else
                            {
                                datBitmap = dr.Value.map.GetBitmap();
                            }
                        }
                        else
                        {
                            datBitmap = (Bitmap)DummyTexture.Clone();
                        }
                        break;
                    default:
                        datBitmap = (Bitmap)DummyTexture.Clone();
                        break;
                }
                gl.BindTexture(OpenGL.GL_TEXTURE_2D, dr.Value.textureID);
                gl.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, /*OpenGL.GL_RGB16*/3, datBitmap.Width, datBitmap.Height, 0, OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE,
                    datBitmap.LockBits(new System.Drawing.Rectangle(0, 0, datBitmap.Width, datBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb).Scan0);

                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);
                gl.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MAG_FILTER, OpenGL.GL_LINEAR);
            });
        }

        private Bitmap CreateCheckerBitmap(bool random = false)
        {
            const int colWidth = 16;
            const int rowHeight = 16;
            System.Drawing.Bitmap checks = new System.Drawing.Bitmap(
                colWidth * 16, rowHeight * 16);
            // The checkerboard consists of 10 rows and 10 columns.
            // Each square in the checkerboard is 10 x 10 pixels.
            // The nested for loops are used to calculate the position
            // of each square on the bitmap surface, and to set the
            // pixels to black or white.

            // The two outer loops iterate through 
            //  each square in the bitmap surface.

            System.Drawing.Color B = System.Drawing.Color.Black;
            System.Drawing.Color A = System.Drawing.Color.White;

            if(random) B = System.Drawing.Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));

            for (int columns = 0; columns < 16; columns++)
            {
                for (int rows = 0; rows < 16; rows++)
                {
                    // Determine whether the current sqaure
                    // should be black or white.
                    System.Drawing.Color color;
                    if (columns % 2 == 0)
                        color = rows % 2 == 0 ? B : A;
                    else
                        color = rows % 2 == 0 ? A : B;
                    // The two inner loops iterate through
                    // each pixel in an individual square.
                    for (int j = columns * colWidth; j < (columns * colWidth) +
                        colWidth; j++)
                    {
                        for (int k = rows * rowHeight; k < (rows * rowHeight) +
                            rowHeight; k++)
                        {
                            // Set the pixel to the correct color.
                            checks.SetPixel(j, k, color);
                        }
                    }
                }
            }

            return checks;
        }

        private void openGLControl_MouseWheel(object sender, MouseEventArgs e)
        {
            zoom += (e.Delta * -0.005);
            zoom = Math.Min(1000.0d, Math.Max(zoom, 0.00001d));
        }

        private void openGLControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseLeftActive)
            {
                if (e.Button == MouseButtons.Left)
                {
                    rotation += ((e.X - oldMouseX) / (float)openGLControl.Width * 250f);
                    oldMouseX = e.X;

                    pitch += ((e.Y - oldMouseY) / (float)openGLControl.Height * 250f);
                    oldMouseY = e.Y;
                }
                else
                {
                    MouseLeftActive = false;
                }
            }
            if (MouseRightActive)
            {
                if (e.Button == MouseButtons.Right)
                {
                    transX += ((e.X - oldMouseX) / (float)openGLControl.Width * 25f);
                    oldMouseX = e.X;

                    transY += ((e.Y - oldMouseY) / (float)openGLControl.Height * 25f);
                    oldMouseY = e.Y;
                }
                else
                {
                    MouseRightActive = false;
                }
            }
        }

        private void openGLControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                oldMouseX = e.X;
                oldMouseY = e.Y;
                MouseLeftActive = true;
            }
            if (e.Button == MouseButtons.Right)
            {
                oldMouseX = e.X;
                oldMouseY = e.Y;
                MouseRightActive = true;
            }
        }

        private void openGLControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseLeftActive = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                MouseRightActive = false;
            }
        }

        private void btnBackgroundColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //  Get the OpenGL object.
                OpenGL gl = openGLControl.OpenGL;

                //  Set the clear color.
                gl.ClearColor(colorDialog1.Color.R / 255.0f, colorDialog1.Color.G / 255.0f, colorDialog1.Color.B / 255.0f, colorDialog1.Color.A / 255.0f);
                btnBackgroundColor.BackColor = colorDialog1.Color;
            }
        }

        private void cbRender_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)cbRender.SelectedItem)
            {
                case "Special: TreeBranch":
                    curRenderStyle = RenderStyle.Special_Back_Front;
                    break;
                case "Special: Area":
                    curRenderStyle = RenderStyle.FaceArea;
                    break;
                case "Wire":
                    curRenderStyle = RenderStyle.Wire;
                    break;
                case "Solid":
                    curRenderStyle = RenderStyle.Solid;
                    break;
                case "Color":
                    curRenderStyle = RenderStyle.Color;
                    break;
                case "Checker":
                    curRenderStyle = RenderStyle.Checker;
                    break;
                case "Texture":
                    curRenderStyle = RenderStyle.Texture;
                    break;
            }

            UpdateOGLTextureData();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (geo != null)
            {
                geo.header.Name_STR = txtName.Text;
            }
        }

        private Color Lerp(Color color1, Color color2, float amount)
        {
            const float bitmask = 65536.0f;
            uint n = (uint)(Math.Round(Math.Max(Math.Min((amount * bitmask), bitmask), 0.0f)));
            int r = ((int)(color1.R) + ((((int)(color2.R) - (int)(color1.R)) * (int)(n)) >> 16));
            int g = ((int)(color1.G) + ((((int)(color2.G) - (int)(color1.G)) * (int)(n)) >> 16));
            int b = ((int)(color1.B) + ((((int)(color2.B) - (int)(color1.B)) * (int)(n)) >> 16));
            //int a = ((int)(color1.A) + ((((int)(color2.A) - (int)(color1.A)) * (int)(n)) >> 16));
            return Color.FromArgb(/*a,*/ r, g, b);
        }

        private void lstFaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblFaceCount.Text = lstFaces.SelectedItems.Count.ToString();

            if (geo != null && lstFaces.SelectedIndex > -1)
            {
                DisableEvents = true;

                Face face = ((FaceListWrapper)lstFaces.SelectedItem).Value;
                byte? r = face.Color.r;
                byte? g = face.Color.g;
                byte? b = face.Color.b;
                byte? ShadeType = face.ShadeType;
                byte? XluscentType = face.XluscentType;
                bool? TextureType_TRUE_PERSPECTIVE = face.TextureType_TRUE_PERSPECTIVE;
                bool? TextureType_TILED_TEXTUREMAP = face.TextureType_TILED_TEXTUREMAP;
                bool? TextureType_XPARENT_TEXTMAP = face.TextureType_XPARENT_TEXTMAP;
                string TextureName = face.TextureName_STR;

                foreach(FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    if (r.HasValue && r != faceWrapper.Value.Color.r) r = null;
                    if (r.HasValue && g != faceWrapper.Value.Color.g) g = null;
                    if (r.HasValue && b != faceWrapper.Value.Color.b) b = null;

                    if (ShadeType   .HasValue && ShadeType    != faceWrapper.Value.ShadeType   ) ShadeType    = null;
                    if (XluscentType.HasValue && XluscentType != faceWrapper.Value.XluscentType) XluscentType = null;

                    if (TextureType_TRUE_PERSPECTIVE.HasValue && TextureType_TRUE_PERSPECTIVE != faceWrapper.Value.TextureType_TRUE_PERSPECTIVE) TextureType_TRUE_PERSPECTIVE = null;
                    if (TextureType_TILED_TEXTUREMAP.HasValue && TextureType_TILED_TEXTUREMAP != faceWrapper.Value.TextureType_TILED_TEXTUREMAP) TextureType_TILED_TEXTUREMAP = null;
                    if (TextureType_XPARENT_TEXTMAP .HasValue && TextureType_XPARENT_TEXTMAP  != faceWrapper.Value.TextureType_XPARENT_TEXTMAP ) TextureType_XPARENT_TEXTMAP  = null;

                    if (TextureName != null && TextureName != faceWrapper.Value.TextureName_STR) TextureName = null;
                }

                cbPerspectiveSW.CheckState = CheckState.Unchecked;
                cbTiled.CheckState = CheckState.Unchecked;
                cbTextTransp.CheckState = CheckState.Unchecked;

                if (r.HasValue && g.HasValue && b.HasValue) { btnFaceColor.BackColor = colorDialog1.Color = Color.FromArgb(r.Value, g.Value, b.Value); } else { btnFaceColor.BackColor = SystemColors.Control; colorDialog1.Color = Color.White; }
                if (ShadeType.HasValue) { cbShadeType.SelectedIndex = ShadeType.Value - 1; } else { cbShadeType.SelectedIndex = -1; }
                if (XluscentType.HasValue) { cbTransparent.SelectedIndex = XluscentType.Value; } else { cbTransparent.SelectedIndex = -1; }
                if (TextureType_TRUE_PERSPECTIVE.HasValue) { cbPerspectiveSW.Checked = TextureType_TRUE_PERSPECTIVE.Value; } else { cbPerspectiveSW.CheckState = CheckState.Indeterminate; }
                if (TextureType_TILED_TEXTUREMAP.HasValue) { cbTiled.Checked = TextureType_TILED_TEXTUREMAP.Value; } else { cbTiled.CheckState = CheckState.Indeterminate; }
                if (TextureType_XPARENT_TEXTMAP.HasValue) { cbTextTransp.Checked = TextureType_XPARENT_TEXTMAP.Value; } else { cbTextTransp.CheckState = CheckState.Indeterminate; }
                if (TextureName != null) { cbTexture.SelectedItem = TextureName; } else { cbTexture.SelectedIndex = -1; }

                btnFaceColor.Enabled = true;
                cbShadeType.Enabled = true;
                cbTransparent.Enabled = true;
                cbPerspectiveSW.Enabled = true;
                cbTiled.Enabled = true;
                cbTextTransp.Enabled = true;
                cbTexture.Enabled = true;

                DisableEvents = false;
            }
            else
            {
                DisableEvents = true;

                btnFaceColor.Enabled = false;
                cbShadeType.Enabled = false;
                cbTransparent.Enabled = false;
                cbPerspectiveSW.Enabled = false;
                cbTiled.Enabled = false;
                cbTextTransp.Enabled = false;
                cbTexture.Enabled = false;

                btnFaceColor.BackColor = SystemColors.Control;
                colorDialog1.Color = Color.White;
                cbShadeType.SelectedIndex = -1;
                cbTransparent.SelectedIndex = -1;
                cbPerspectiveSW.CheckState = CheckState.Indeterminate;
                cbTiled.CheckState = CheckState.Indeterminate;
                cbTextTransp.CheckState = CheckState.Indeterminate;
                cbTexture.SelectedIndex = -1;

                DisableEvents = false;
            }
        }

        private void btnFaceColor_Click(object sender, EventArgs e)
        {
            if (geo != null && lstFaces.SelectedIndex > -1)
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                    {
                        Face face = faceWrapper.Value;
                        face.Color.r = colorDialog1.Color.R;
                        face.Color.g = colorDialog1.Color.G;
                        face.Color.b = colorDialog1.Color.B;
                    }

                    btnFaceColor.BackColor = colorDialog1.Color;
                }
            }
        }

        private void cbShadeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.ShadeType = (byte)(cbShadeType.SelectedIndex + 1);
                }
            }
        }

        private void cbTransparent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.XluscentType = (byte)cbTransparent.SelectedIndex;
                }
            }
        }

        private void cbTexture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.TextureName_STR = (string)cbTexture.SelectedItem;
                }
            }
        }

        private void cbPerspectiveSW_CheckedChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.TextureType_TRUE_PERSPECTIVE = cbPerspectiveSW.Checked;
                }
            }
        }

        private void cbTiled_CheckedChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.TextureType_TILED_TEXTUREMAP = cbTiled.Checked;
                }
            }
        }

        private void cbTextTransp_CheckedChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lstFaces.SelectedIndex > -1)
            {
                foreach (FaceListWrapper faceWrapper in lstFaces.SelectedItems)
                {
                    Face face = faceWrapper.Value;
                    face.TextureType_XPARENT_TEXTMAP = cbTextTransp.Checked;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutDialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(geo != null)
            {
                saveFileDialog1.ShowDialog();
            }
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if (geo != null)
            {
                geo.Save(saveFileDialog1.FileName);
            }
        }

        private void cbHeaderFlag_Check(object sender, EventArgs e)
        {
            if (!DisableEvents)
            {
                if (geo != null)
                {
                    if (sender == cbHeaderFlag1) geo.header.Flags_GOURAUD_SHADED = cbHeaderFlag1.Checked;
                    if (sender == cbHeaderFlag2) geo.header.Flags_TILED_BITMAP = cbHeaderFlag2.Checked;
                    if (sender == cbHeaderFlag3) geo.header.Flags_TEXTURE_MAP = cbHeaderFlag3.Checked;
                    if (sender == cbHeaderFlag4) geo.header.Flags_PARALLEL = cbHeaderFlag4.Checked;
                    if (sender == cbHeaderFlag5) geo.header.Flags_TRUE_PERSPECTIVE = cbHeaderFlag5.Checked;
                    if (sender == cbHeaderFlag6) geo.header.Flags_WIRE_FRAME = cbHeaderFlag6.Checked;
                    if (sender == cbHeaderFlag7) geo.header.Flags_TRANSPARENT_PIXELS = cbHeaderFlag7.Checked;
                    if (sender == cbHeaderFlag8) geo.header.Flags_ONE_THIRD_TRANSLUCENT_PIXELS = cbHeaderFlag8.Checked;
                    if (sender == cbHeaderFlag9) geo.header.Flags_PROJECT_POLYGON_ONLY = cbHeaderFlag9.Checked;
                    if (sender == cbHeaderFlag10) geo.header.Flags_Composit_ALPHA_BLEND = cbHeaderFlag10.Checked;
                    if (sender == cbHeaderFlag11) geo.header.Flags_Composit_TWO_THIRD_TRANSLUCENT_PIXELS = cbHeaderFlag11.Checked;
                    if (sender == cbHeaderFlag12) geo.header.Flags_Composit_FLAT_PERSPECTIVE_MAP = cbHeaderFlag12.Checked;
                    if (sender == cbHeaderFlag13) geo.header.Flags_Composit_FLAT_TILED_PERSPECTIVE_MAP = cbHeaderFlag13.Checked;
                    if (sender == cbHeaderFlag14) geo.header.Flags_Composit_HALLOW_WIRE_FRAME = cbHeaderFlag14.Checked;
                }
                setHeaderCheckboxes();
            }
        }

        private void setHeaderCheckboxes()
        {
            DisableEvents = true;
            if (geo != null)
            {
                cbHeaderFlag1.CheckState = CheckState.Unchecked;
                cbHeaderFlag2.CheckState = CheckState.Unchecked;
                cbHeaderFlag3.CheckState = CheckState.Unchecked;
                cbHeaderFlag4.CheckState = CheckState.Unchecked;
                cbHeaderFlag5.CheckState = CheckState.Unchecked;
                cbHeaderFlag6.CheckState = CheckState.Unchecked;
                cbHeaderFlag7.CheckState = CheckState.Unchecked;
                cbHeaderFlag8.CheckState = CheckState.Unchecked;
                cbHeaderFlag9.CheckState = CheckState.Unchecked;
                cbHeaderFlag10.CheckState = CheckState.Unchecked;
                cbHeaderFlag11.CheckState = CheckState.Unchecked;
                cbHeaderFlag12.CheckState = CheckState.Unchecked;
                cbHeaderFlag13.CheckState = CheckState.Unchecked;
                cbHeaderFlag14.CheckState = CheckState.Unchecked;

                cbHeaderFlag1.Checked = geo.header.Flags_GOURAUD_SHADED;
                cbHeaderFlag2.Checked = geo.header.Flags_TILED_BITMAP;
                cbHeaderFlag3.Checked = geo.header.Flags_TEXTURE_MAP;
                cbHeaderFlag4.Checked = geo.header.Flags_PARALLEL;
                cbHeaderFlag5.Checked = geo.header.Flags_TRUE_PERSPECTIVE;
                cbHeaderFlag6.Checked = geo.header.Flags_WIRE_FRAME;
                cbHeaderFlag7.Checked = geo.header.Flags_TRANSPARENT_PIXELS;
                cbHeaderFlag8.Checked = geo.header.Flags_ONE_THIRD_TRANSLUCENT_PIXELS;
                cbHeaderFlag9.Checked = geo.header.Flags_PROJECT_POLYGON_ONLY;
                cbHeaderFlag10.Checked = geo.header.Flags_Composit_ALPHA_BLEND;
                cbHeaderFlag11.Checked = geo.header.Flags_Composit_TWO_THIRD_TRANSLUCENT_PIXELS;
                cbHeaderFlag12.Checked = geo.header.Flags_Composit_FLAT_PERSPECTIVE_MAP;
                cbHeaderFlag13.Checked = geo.header.Flags_Composit_FLAT_TILED_PERSPECTIVE_MAP;
                cbHeaderFlag14.Checked = geo.header.Flags_Composit_HALLOW_WIRE_FRAME;

                cbHeaderFlag1.Enabled = true;
                cbHeaderFlag2.Enabled = true;
                cbHeaderFlag3.Enabled = true;
                cbHeaderFlag4.Enabled = true;
                cbHeaderFlag5.Enabled = true;
                cbHeaderFlag6.Enabled = true;
                cbHeaderFlag7.Enabled = true;
                cbHeaderFlag8.Enabled = true;
                cbHeaderFlag9.Enabled = true;
                cbHeaderFlag10.Enabled = true;
                cbHeaderFlag11.Enabled = true;
                cbHeaderFlag12.Enabled = true;
                cbHeaderFlag13.Enabled = true;
                cbHeaderFlag14.Enabled = true;
            }
            else
            {
                cbHeaderFlag1.Enabled = false;
                cbHeaderFlag2.Enabled = false;
                cbHeaderFlag3.Enabled = false;
                cbHeaderFlag4.Enabled = false;
                cbHeaderFlag5.Enabled = false;
                cbHeaderFlag6.Enabled = false;
                cbHeaderFlag7.Enabled = false;
                cbHeaderFlag8.Enabled = false;
                cbHeaderFlag9.Enabled = false;
                cbHeaderFlag10.Enabled = false;
                cbHeaderFlag11.Enabled = false;
                cbHeaderFlag12.Enabled = false;
                cbHeaderFlag13.Enabled = false;
                cbHeaderFlag14.Enabled = false;

                cbHeaderFlag1.CheckState = CheckState.Indeterminate;
                cbHeaderFlag2.CheckState = CheckState.Indeterminate;
                cbHeaderFlag3.CheckState = CheckState.Indeterminate;
                cbHeaderFlag4.CheckState = CheckState.Indeterminate;
                cbHeaderFlag5.CheckState = CheckState.Indeterminate;
                cbHeaderFlag6.CheckState = CheckState.Indeterminate;
                cbHeaderFlag7.CheckState = CheckState.Indeterminate;
                cbHeaderFlag8.CheckState = CheckState.Indeterminate;
                cbHeaderFlag9.CheckState = CheckState.Indeterminate;
                cbHeaderFlag10.CheckState = CheckState.Indeterminate;
                cbHeaderFlag11.CheckState = CheckState.Indeterminate;
                cbHeaderFlag12.CheckState = CheckState.Indeterminate;
                cbHeaderFlag13.CheckState = CheckState.Indeterminate;
                cbHeaderFlag14.CheckState = CheckState.Indeterminate;
            }
            DisableEvents = false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            //  Get the OpenGL object.
            OpenGL gl = openGLControl.OpenGL;

            float val = trackBar1.Value / 10.0f;

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, new float[] { val, val, val });
        }

        private void tvFaces_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void tmrNotes_Tick(object sender, EventArgs e)
        {
            tmrNotes.Stop();
            using(FileStream stream = File.Open("notes.txt", FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(txtNotes.Text);
                }
            }
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            if (notesLoaded)
            {
                tmrNotes.Stop();
                tmrNotes.Start();
            }
        }

        private void lbTextures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DisableEvents && geo != null && lbTextures.SelectedIndex > -1 && checkerBitmaps.ContainsKey((string)lbTextures.SelectedItem))
            {
                TextureDataMap text = checkerBitmaps[(string)lbTextures.SelectedItem];
                if (text.map != null)
                {
                    if (text.map.IsPalletized && text.pallet != null)
                    {
                        pbTexture.Image = text.map.GetBitmap(text.pallet);
                    }
                    else
                    {
                        pbTexture.Image = text.map.GetBitmap();
                    }
                    pbTexture.Size = pbTexture.Image.Size;
                }
                else
                {
                    pbTexture.Image = null;
                    pbTexture.Height = 0;
                    pbTexture.Width = 0;
                }
                if (text.pallet != null && text.pallet.Length > 0)
                {
                    Bitmap act = new Bitmap(text.pallet.Length, 1);
                    for (int x = 0; x < text.pallet.Length; x++)
                    {
                        act.SetPixel(x, 0, text.pallet[x]);
                    }
                    pbPallet.Image = act;
                }
                else
                {
                    pbPallet.Image = null;
                }

                if (lbTextures.Items.Count > 1)
                {
                    btnRemoveTexture.Enabled = true;
                }
                else
                {
                    btnRemoveTexture.Enabled = false;
                }
            }
            else
            {
                pbTexture.Image = null;
                pbTexture.Height = 0;
                pbTexture.Width = 0;
                pbPallet.Image = null;

                btnRemoveTexture.Enabled = false;
            }
        }

        private void btnAddTexture_Click(object sender, EventArgs e)
        {
            AddTextureDialog dlg = new AddTextureDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if(AddTexture(dlg.Value))
                {
                    UpdateOGLTextureData();
                }
            }
        }

        private bool AddTexture(string name, bool randomTexture = false)
        {
            name = name.Trim();
            name = name.Substring(0, Math.Min(13, name.Length));

            if (checkerBitmaps.ContainsKey(name)) return false;

            OpenGL gl = openGLControl.OpenGL;

            ////////////////////////////////////////////////////////////////////////////////
            TextureDataMap tmpTD = new TextureDataMap() { checker = CreateCheckerBitmap(randomTexture) };
            gl.GenTextures(1, tmpTD._textureID);

            gl.BindTexture(OpenGL.GL_TEXTURE_2D, tmpTD.textureID);

            checkerBitmaps.Add(name, tmpTD);

            loadMAPToolStripMenuItem.DropDownItems.Add(name, null, OpenMap_Click);
            clearMAPToolStripMenuItem.DropDownItems.Add(name, null, ClearMap_Click);
            loadACTToolStripMenuItem.DropDownItems.Add(name, null, OpenAct_Click);
            clearACTToolStripMenuItem.DropDownItems.Add(name, null, ClearAct_Click);
            cbTexture.Items.Add(name);
            lbTextures.Items.Add(name);
            ////////////////////////////////////////////////////////////////////////////////

            string MAPFILE = path + Path.DirectorySeparatorChar + name + ".map";
            if (File.Exists(MAPFILE))
            {
                tmpTD.map = MapFile.FromFile(MAPFILE);
            }

            string ACTFILE = path + Path.DirectorySeparatorChar + "objects.act";
            if (File.Exists(ACTFILE))
            {
                tmpTD.pallet = MapFile.PalletFromFile(ACTFILE);
            }
            else
            {
                ACTFILE = "objects.act";
                if (File.Exists(ACTFILE))
                {
                    tmpTD.pallet = MapFile.PalletFromFile(ACTFILE);
                }
            }

            return true;
        }

        private bool RemoveTexture(string name)
        {
            name = name.Trim();
            name = name.Substring(0, Math.Min(13, name.Length));

            if (!checkerBitmaps.ContainsKey(name)) return false;

            geo.faces.ForEach(face =>
            {
                if (face.TextureName_STR == name) face.TextureName_STR = checkerBitmaps.Keys.Where(dr => dr != name).First();
            });

            TextureDataMap tmpTD = checkerBitmaps[name];
            checkerBitmaps.Remove(name);

            OpenGL gl = openGLControl.OpenGL;

            gl.DeleteTextures(1, tmpTD._textureID);

            { ToolStripItem itm_Remove = null; foreach (ToolStripItem itm in loadMAPToolStripMenuItem.DropDownItems) { if (itm.Text == name) { itm_Remove = itm; break; } } loadMAPToolStripMenuItem.DropDownItems.Remove(itm_Remove); }
            { ToolStripItem itm_Remove = null; foreach (ToolStripItem itm in clearMAPToolStripMenuItem.DropDownItems) { if (itm.Text == name) { itm_Remove = itm; break; } } clearMAPToolStripMenuItem.DropDownItems.Remove(itm_Remove); }
            { ToolStripItem itm_Remove = null; foreach (ToolStripItem itm in loadACTToolStripMenuItem.DropDownItems) { if (itm.Text == name) { itm_Remove = itm; break; } } loadACTToolStripMenuItem.DropDownItems.Remove(itm_Remove); }
            { ToolStripItem itm_Remove = null; foreach (ToolStripItem itm in clearACTToolStripMenuItem.DropDownItems) { if (itm.Text == name) { itm_Remove = itm; break; } } clearACTToolStripMenuItem.DropDownItems.Remove(itm_Remove); }

            cbTexture.Items.Remove(name);
            lbTextures.Items.Remove(name);

            UpdateOGLTextureData();

            return true;
        }

        private void btnRemoveTexture_Click(object sender, EventArgs e)
        {
            if (lbTextures.SelectedIndex > -1)
            {
                RemoveTexture((string)lbTextures.SelectedItem);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lstFacesUV_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUVGraphics();
        }

        private void UpdateUVGraphics(float? dx = null, float? dy = null)
        {
            if (lstFacesUV.SelectedIndex > -1)
            {
                string TextureName = ((FaceListWrapper)(lstFacesUV.SelectedItems[0])).Value.TextureName_STR;

                foreach (FaceListWrapper wrapper in lstFacesUV.SelectedItems)
                {
                    if (TextureName != wrapper.Value.TextureName_STR)
                    {
                        TextureName = null;
                        break;
                    }
                }

                if (TextureName != null && checkerBitmaps.ContainsKey(TextureName))
                {
                    TextureDataMap dat = checkerBitmaps[TextureName];
                    Image tmpImg = null;

                    if (dat.map != null)
                    {
                        if (dat.map.IsPalletized && dat.pallet != null)
                        {
                            tmpImg = dat.map.GetBitmap(dat.pallet);
                        }
                        else
                        {
                            tmpImg = dat.map.GetBitmap();
                        }
                    }
                    else
                    {
                        tmpImg = CreateCheckerBitmap();
                    }

                    nudZoom.Enabled = true;
                    nudZoom.Maximum = Math.Max(1, (int)(512 / Math.Max(tmpImg.Width, tmpImg.Height)));

                    int scaleFactor = (int)nudZoom.Value;
                    Image tmpImg2 = (Image)new Bitmap(tmpImg.Width * scaleFactor, tmpImg.Height * scaleFactor);
                    using (Graphics g = Graphics.FromImage(tmpImg2))
                    {
                        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                        g.DrawImage(tmpImg, 0, 0, tmpImg.Width * scaleFactor, tmpImg.Height * scaleFactor);
                    }
                    tmpImg.Dispose();
                    tmpImg = tmpImg2;

                    pbTextureUV.Image = new Bitmap(tmpImg.Width * 3, tmpImg.Height * 3);
                    using (Graphics g = Graphics.FromImage(pbTextureUV.Image))
                    {
                        for (int x = 0; x < 3; x++)
                        {
                            for (int y = 0; y < 3; y++)
                            {
                                g.DrawImageUnscaled(tmpImg, x * tmpImg.Width, y * tmpImg.Height);
                                if (x != 1 || y != 1)
                                {
                                    g.FillRectangle(new SolidBrush(Color.FromArgb(128, 0, 0, 0)), x * tmpImg.Width, y * tmpImg.Height, tmpImg.Width, tmpImg.Height);
                                }
                            }
                        }

                        g.DrawLines(new Pen(Color.FromArgb(128, 0, 0, 255)), new Point[] {
                            new Point(tmpImg.Width - 1, tmpImg.Height - 1),
                            new Point(tmpImg.Width + tmpImg.Width, tmpImg.Height - 1),
                            new Point(tmpImg.Width + tmpImg.Width, tmpImg.Height + tmpImg.Height),
                            new Point(tmpImg.Width - 1, tmpImg.Height + tmpImg.Height),
                            new Point(tmpImg.Width - 1, tmpImg.Height - 1)
                        });

                        List<Rectangle> rects = new List<Rectangle>();
                        List<Rectangle> rects2 = new List<Rectangle>();
                        List<List<Point>> points = new List<List<Point>>();
                        foreach (FaceListWrapper wrapper in lstFacesUV.SelectedItems)
                        {
                            Face f = wrapper.Value;

                            List<Point> subpoints = new List<Point>();
                            points.Add(subpoints);
                            subpoints.Add(new Point((int)(f.Wireframe[f.VertexCount - 1].u * tmpImg.Width) + tmpImg.Width, (int)(f.Wireframe[f.VertexCount - 1].v * tmpImg.Height) + tmpImg.Height));
                            for (int v = 0; v < f.VertexCount; v++)
                            {
                                FaceNode node = f.Wireframe[v];

                                if (SelectedUVs.Contains(node))
                                {
                                    if (dx.HasValue && dy.HasValue)
                                    {
                                        rects2.Add(new Rectangle((int)((node.u + dx.Value) * tmpImg.Width) - 2 + tmpImg.Width, (int)((node.v + dy.Value) * tmpImg.Height) - 2 + tmpImg.Height, 5, 5));
                                    }
                                    else
                                    {
                                        rects2.Add(new Rectangle((int)(node.u * tmpImg.Width) - 2 + tmpImg.Width, (int)(node.v * tmpImg.Height) - 2 + tmpImg.Height, 5, 5));
                                    }
                                }
                                else
                                {
                                    rects.Add(new Rectangle((int)(node.u * tmpImg.Width) - 2 + tmpImg.Width, (int)(node.v * tmpImg.Height) - 2 + tmpImg.Height, 5, 5));
                                }
                                subpoints.Add(new Point((int)(node.u * tmpImg.Width) + tmpImg.Width, (int)(node.v * tmpImg.Height) + tmpImg.Height));
                            }
                        }
                        if (rects.Count > 0) { g.DrawRectangles(new Pen(Color.Blue), rects.ToArray()); }
                        if (rects2.Count > 0) { g.DrawRectangles(new Pen(Color.Red), rects2.ToArray()); }
                        points.ForEach(subpoints =>
                        {
                            if (subpoints.Count > 0) { g.DrawLines(new Pen(Color.LightGreen), subpoints.ToArray()); }
                        });
                    }
                    tmpImg.Dispose();
                    pbTextureUV.Size = pbTextureUV.Image.Size;
                }
                else
                {
                    pbTextureUV.Image = null;
                    pbTextureUV.Height = 0;
                    pbTextureUV.Width = 0;
                }
            }
            else
            {
                pbTextureUV.Image = null;
                pbTextureUV.Height = 0;
                pbTextureUV.Width = 0;

                nudZoom.Enabled = true;
                nudZoom.Maximum = 1;
            }
        }

        private List<FaceNode> SelectedUVs = new List<FaceNode>();
        float UVStartX = 0.0f;
        float UVStartY = 0.0f;
        bool DraggingUV = false;

        private void pbTextureUV_MouseDown(object sender, MouseEventArgs e)
        {
            SelectedUVs.Clear();

            if (e.Button == MouseButtons.Left)
            {
                if (lstFacesUV.SelectedIndex > -1)
                {
                    if (pbTextureUV.Image != null)
                    {
                        int w = pbTextureUV.Image.Width / 3;
                        int h = pbTextureUV.Image.Height / 3;
                        UVStartX = (e.X - w) * 1.0f / w;
                        UVStartY = (e.Y - h) * 1.0f / h;

                        foreach (FaceListWrapper wrapper in lstFacesUV.SelectedItems)
                        {
                            //foreach(FaceNode node in wrapper.Value.Wireframe)
                            for (int z = 0; z < wrapper.Value.VertexCount; z++)
                            {
                                FaceNode node = wrapper.Value.Wireframe[z];
                                if (Math.Abs(node.u - UVStartX) < 0.02f && Math.Abs(node.v - UVStartY) < 0.02f)
                                {
                                    //Console.WriteLine("{0},{1}", node.u, node.v);
                                    SelectedUVs.Add(node);
                                }
                            }
                        }
                        DraggingUV = true;
                        tmrUV.Start();
                    }
                }
                UpdateUVGraphics();
            }else if(e.Button == MouseButtons.Right)
            {
                SelectedUVs.Clear();
                UpdateUVGraphics();
                DraggingUV = false;
            }
        }

        private void pbTextureUV_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (SelectedUVs.Count > 0)
                {
                    if (lstFacesUV.SelectedIndex > -1)
                    {
                        if (pbTextureUV.Image != null)
                        {
                            int w = pbTextureUV.Image.Width / 3;
                            int h = pbTextureUV.Image.Height / 3;
                            float x = (e.X - w) * 1.0f / w;
                            float y = (e.Y - h) * 1.0f / h;

                            float dX = x - UVStartX;
                            float dY = y - UVStartY;

                            foreach (FaceListWrapper wrapper in lstFacesUV.SelectedItems)
                            {
                                for (int z = 0; z < wrapper.Value.VertexCount; z++)
                                {
                                    if (SelectedUVs.Contains(wrapper.Value.Wireframe[z]))
                                    {
                                        wrapper.Value.Wireframe[z].u += dX;
                                        wrapper.Value.Wireframe[z].v += dY;
                                    }
                                }
                            }

                            tmrUV.Start();

                            DraggingUV = false;
                        }
                    }

                    SelectedUVs.Clear();
                    UpdateUVGraphics();
                }
            }
        }

        float UVdX = 0.0f;
        float UVdY = 0.0f;

        private void pbTextureUV_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (SelectedUVs.Count > 0)
                {
                    if (lstFacesUV.SelectedIndex > -1)
                    {
                        if (pbTextureUV.Image != null)
                        {
                            int w = pbTextureUV.Image.Width / 3;
                            int h = pbTextureUV.Image.Height / 3;
                            float x = (e.X - w) * 1.0f / w;
                            float y = (e.Y - h) * 1.0f / h;

                            UVdX = x - UVStartX;
                            UVdY = y - UVStartY;

                            if (!tmrUV.Enabled) tmrUV.Start();
                        }
                        else { tmrUV.Stop(); }
                    }
                    else { tmrUV.Stop(); }
                }
                else { tmrUV.Stop(); }
            }
            else { tmrUV.Stop(); }
        }

        private void tmrUV_Tick(object sender, EventArgs e)
        {
            if (SelectedUVs.Count > 0)
            {
                if (lstFacesUV.SelectedIndex > -1)
                {
                    if (pbTextureUV.Image != null)
                    {
                        UpdateUVGraphics(UVdX, UVdY);
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (DraggingUV)
            {
                switch (keyData)
                {
                    case Keys.W:
                        Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y - 1);
                        break;
                    case Keys.D:
                        Cursor.Position = new Point(Cursor.Position.X + 1, Cursor.Position.Y);
                        break;
                    case Keys.S:
                        Cursor.Position = new Point(Cursor.Position.X, Cursor.Position.Y + 1);
                        break;
                    case Keys.A:
                        Cursor.Position = new Point(Cursor.Position.X - 1, Cursor.Position.Y);
                        break;
                    default:
                        break;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void nudZoom_ValueChanged(object sender, EventArgs e)
        {
            UpdateUVGraphics();
        }

        private void exportOBJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(geo != null)
            {
                if(saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream fstream = File.Open(Path.ChangeExtension(saveFileDialog2.FileName,"mtl"), FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fstream))
                        {
                            textureNames.ForEach(text =>
                            {
                                writer.WriteLine("newmtl {0}", text);
                                writer.WriteLine("Ka 1.000000 1.000000 1.000000");
                                writer.WriteLine("Kd 1.000000 1.000000 1.000000");
                                writer.WriteLine("Ks 0.000000 0.000000 0.000000");
                                writer.WriteLine("Tr 1.000000");
                                writer.WriteLine("illum 1");
                                writer.WriteLine("Ns 0.000000");
                                writer.WriteLine("map_Kd {0}.bmp", text);
                                writer.WriteLine();
                            });
                        }
                    }
                    using (FileStream fstream = File.Open(saveFileDialog2.FileName, FileMode.Create))
                    {
                        using (StreamWriter writer = new StreamWriter(fstream))
                        {
                            writer.WriteLine("mtllib {0}", Path.ChangeExtension(Path.GetFileName(saveFileDialog2.FileName), "mtl"));
                            writer.WriteLine();

                            foreach(Vector3D vect in geo.vecs)
                            {
                                writer.WriteLine("v {0} {1} {2}", -vect.x, -vect.z, vect.y);
                            }
                            writer.WriteLine();

                            geo.faces.ForEach(face =>
                            {
                                foreach (FaceNode node in face.Wireframe)
                                {
                                    writer.WriteLine("vt {0} {1}", node.u, 1 - node.v);
                                }
                            });
                            writer.WriteLine();

                            foreach(Vector3D vect in geo.vecnorms)
                            {
                                writer.WriteLine("vn {0} {1} {2}", -vect.x, -vect.z, vect.y);
                            }
                            writer.WriteLine();

                            int uvcounter = 1;
                            geo.faces.ForEach(face =>
                            {
                                writer.WriteLine("usemtl {0}", face.TextureName_STR);

                                writer.Write("f");
                                foreach(FaceNode node in face.Wireframe)
                                {
                                    writer.Write(" {0}/{1}/{2}", node.VertexId + 1, uvcounter++, node.VertexNormalId + 1);
                                }
                                writer.WriteLine();
                            });
                        }
                    }
                }
            }
        }
    }
}

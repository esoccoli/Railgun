using Railgun.Editor.App.Objects;
using Railgun.Editor.App.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Railgun.Editor.App.Controls
{
    /// <summary>
    /// A user control of the entity panel
    /// <para>Author: Jonathan Jan</para>
    /// Date Created: 4/30/2023
    /// </summary>
    public partial class EntityPanel : UserControl
    {
        public EntityPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Returns the selected indices collection of the entity list view
        /// </summary>
        public ListView.SelectedIndexCollection SelectedIndices
            => listView_Entities.SelectedIndices;

        /// <summary>
        /// Called when the entity picker is changed
        /// </summary>
        private void ListBox_EntityPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            //If something is selected, set it to the current entity
            if(SelectedIndices.Count > 0)
                EntityManager.Instance.CurrentEntity = SelectedIndices[0];
        }
    }
}

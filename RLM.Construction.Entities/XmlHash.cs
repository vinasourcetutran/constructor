using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;

namespace RLM.Construction.Entities
{
    public class XmlHash
    {
        #region Properties
        public Hashtable Hash { get; set; }

        public string RootTag { get; set; }
        #endregion

        #region Methods
        public void Set(string key, object value)
        {
            this.Hash[key] = value;
        }
        public string GetKeyFromHash(string key)
        {
            if (this.Hash != null && this.Hash[key]!=null) { return (string)this.Hash[key]; }
            return string.Empty;
        }

        public void Import(string xml)
        {
            try
            {
                this.Hash = new Hashtable();
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);
                XmlNode rootNode = doc.ChildNodes[0];
                this.RootTag = rootNode.Name;
                foreach (XmlNode node in rootNode.ChildNodes)
                {
                    this.Hash[node.Name] = node.InnerText;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public override string ToString()
        {
            try
            {
                string xml = string.Empty;
                if (this.Hash == null) { return string.Format("<{0}></{0}>"); }
                foreach (object key in this.Hash.Keys)
                {
                    xml += string.Format("<{0}>{1}</{0}>", key, this.Hash[key]);
                }
                xml = string.Format("<{0}>{1}</{0}>", this.RootTag, xml);
                return xml;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        #endregion

        #region Construction
        public XmlHash()
        {
            this.Hash = new Hashtable();
        }
        public XmlHash(string xml)
        {
            if (string.IsNullOrEmpty(xml)) { this.Hash = new Hashtable(); return; }
            this.Import(xml);
        }
        #endregion

    }
}

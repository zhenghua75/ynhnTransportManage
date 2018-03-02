using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Collections.Specialized;
using System.Configuration.Provider;
using System.Web.Configuration;
using System.Web.Routing;
using DXInfo.Models;
using System.Web.Security;

namespace DXInfo.Sitemap
{
    public class MvcSQLSitemapProvider : StaticSiteMapProvider
    {
        private SiteMapNode _root = null;
        private ynhnTransportManage db = new ynhnTransportManage();
        private Dictionary<string, SiteMapNode> _nodes = new Dictionary<string, SiteMapNode>();
        public override void Initialize(string name, NameValueCollection attributes)
        {
            if (attributes == null)
                throw new ArgumentNullException("attributes");
            if (string.IsNullOrEmpty(name))
                name = "MvcSitemapProvider";
            if (string.IsNullOrEmpty(attributes["description"]))
            {
                attributes.Remove("description");
                attributes.Add("description", "MVC site map provider");
            }
            base.Initialize(name, attributes);
            if (attributes.Count > 0)
            {
                string attr = attributes.GetKey(0);
                if (!string.IsNullOrEmpty(attr))
                    throw new ProviderException(string.Format("Unrecognized attribute: {0}", attr));
            }
        }

        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                if (_root != null)
                {
                    //_root = null;
                    return _root;
                }
                var siteMpaQuery = from s in db.aspnet_Sitemaps
                                   where s.IsMenu == true
                                   orderby s.Code
                                   select s;

                foreach (var item in siteMpaQuery.ToList())
                {
                    if (item.Code == item.ParentCode)
                    {
                        _root = CreateSiteMapFromRow(item);
                        AddNode(_root, null);
                    }
                    else
                    {
                        SiteMapNode node = CreateSiteMapFromRow(item);
                        AddNode(node, GetParentNodeFromNode(item));
                    }
                }

                return _root;
            }
        }


        private SiteMapNode CreateSiteMapFromRow(DXInfo.Models.aspnet_Sitemap item)
        {
            if (_nodes.ContainsKey(item.Code))
                throw new ProviderException(string.Format("重复节点Code={0},Title={1}", item.Code, item.Title));
            SiteMapNode node = new SiteMapNode(this, item.Code);
            node["IsAuthorize"] = item.IsAuthorize.ToString();
            if (!string.IsNullOrEmpty(item.Url))
            {
                node.Title = string.IsNullOrEmpty(item.Title) ? null : item.Title;
                node.Description = string.IsNullOrEmpty(item.Description) ? null : item.Description;
                node.Url = string.IsNullOrEmpty(item.Url) ? null : item.Url;

            }
            else
            {
                node.Title = string.IsNullOrEmpty(item.Title) ? null : item.Title;
                node.Description = string.IsNullOrEmpty(item.Description) ? null : item.Description;

                IDictionary<string, object> routeValues = new Dictionary<string, object>();

                if (string.IsNullOrEmpty(item.Controller))
                    routeValues.Add("controller", "Home");
                else
                    routeValues.Add("controller", item.Controller);

                if (string.IsNullOrEmpty(item.Action))
                    routeValues.Add("action", "Index");
                else
                    routeValues.Add("action", item.Action);

                if (!string.IsNullOrEmpty(item.ParaId))
                    routeValues.Add("id", item.ParaId);

                HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);
                RouteData routeData = RouteTable.Routes.GetRouteData(httpContext);
                if (routeData != null)
                {
                    VirtualPathData virtualPath = routeData.Route.GetVirtualPath(new RequestContext(httpContext, routeData), new RouteValueDictionary(routeValues));

                    if (virtualPath != null)
                    {
                        node.Url = "~/" + virtualPath.VirtualPath;
                    }
                }
            }

            _nodes.Add(item.Code, node);

            return node;
        }

        private SiteMapNode GetParentNodeFromNode(DXInfo.Models.aspnet_Sitemap item)
        {
            if (!_nodes.ContainsKey(item.ParentCode))
                throw new ProviderException(string.Format("无效父节点Code={0},Title={1}", item.Code, item.Title));

            return _nodes[item.ParentCode];
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }
    }
}

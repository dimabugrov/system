﻿using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.Logging;
using ThinkingHome.Core.Plugins;
using ThinkingHome.Plugins.Scripts;
using ThinkingHome.Plugins.WebServer.Attributes;
using ThinkingHome.Plugins.WebServer.Attributes.Base;
using ThinkingHome.Plugins.WebServer.Handlers;

namespace ThinkingHome.Plugins.Tmp
{
    public class UrlValidationPlugin : PluginBase
    {
        private readonly List<string> errors = new List<string>();


        public override void InitPlugin()
        {
            foreach (var plugin in Context.GetAllPlugins())
            {
                ValidateStaticResources(plugin);
            }


        }

        private void AddError(TypeInfo pluginType, string message)
        {
            errors.Add($"[{pluginType}] :: {message}");
        }

        private string GetPluginAlias(TypeInfo pluginType)
        {
            const string PREFIX = "ThinkingHome.Plugins.";

            var name = pluginType.Assembly.GetName().Name;

            if (name.StartsWith(PREFIX))
            {
                name = name.Substring(PREFIX.Length);
            }

            return name.Replace(".", "/").ToLower();
        }

        private void ValidateStaticResources(PluginBase plugin)
        {
            var type = plugin.GetType().GetTypeInfo();
            var alias = GetPluginAlias(type);
            var prefix = $"/static/{alias}/";

            foreach (var resource in type.GetCustomAttributes<HttpStaticResourceAttribute>())
            {
                if (!resource.Url.StartsWith(prefix))
                {
                    AddError(type, $"invalid url prefix: {resource.Url} (required: {prefix})");
                }
            }
        }

        [HttpTextDynamicResource("/url-errors")]
        public object GetUrlErrors(HttpRequestParams requestParams)
        {
            var sb = new StringBuilder();

            errors.ForEach(msg => sb.AppendLine(msg));

            return sb;
        }
    }
}
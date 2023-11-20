using FiyiStackApp.Models.Core;

namespace FiyiStackApp.Generation.JsTsNETCoreSQLServer.Files.CSharp.NETCore
{
    public static class Webpackconfigvendorjs
    {
        public static void Create(Project Project)
        {
            try
            {
                string Content = $@"/*
 * This file/script must be called once before any development process.
 * Run the script 'npm run build-vendor' where the .csproj is present.
 */

 const path = require('path');
 const webpack = require('webpack');
 const MiniCssExtractPlugin = require(""mini-css-extract-plugin"");
 const OptimizeCSSAssetsPlugin = require(""optimize-css-assets-webpack-plugin"");
 const TerserPlugin = require(""terser-webpack-plugin"");
 
 module.exports = {{
     mode: ""production"", //development or production
     entry: {{
         vendor: ['bootstrap', 'jquery','backbone',
             'bootstrap/dist/css/bootstrap.css',
             'font-awesome/css/font-awesome.css'
         ]
     }},
     output: {{
         path: path.join(__dirname, 'wwwroot', 'dist'),  //P1
         publicPath: 'dist/',
         filename: '[name].js',
         library: '[name]_[hash]'
     }},
     resolve: {{
         extensions: ['.js']
     }},
     optimization: {{
         minimizer: [
             new TerserPlugin({{ test: /\.js(\?.*)?$/i }}),
             new OptimizeCSSAssetsPlugin({{}})
         ]
     }},
     module: {{
         rules: [
             {{
                 test: /\.(png|woff|woff2|eot|ttf|jpg|jpeg|gif|svg)$/,
                 use: 'url-loader?limit=10000'
             }},
             {{
                 test: /\.css$/,
                 use: [
                     {{
                         loader: MiniCssExtractPlugin.loader,
                         options: {{
                             publicPath: './'
                         }}
                     }},
                     ""css-loader""
                 ]
             }}
         ]
     }},
     plugins: [
         new webpack.ProvidePlugin({{                                                 //This plugin make jQuery as global in the whole project
             $: 'jquery',
             jQuery: 'jquery',
             'window.jQuery': 'jquery',
             Popper: ['popper.js', 'default']
         }}),
         new webpack.DllPlugin({{
             path: path.join(__dirname, 'wwwroot', 'dist', '[name]-manifest.json'),  //Must be equal to P1 + '[name]-manifest.json'
             name: '[name]_[hash]'
         }}),
         new MiniCssExtractPlugin({{
             filename: ""[name].css"",
             chunkFilename: ""[id].css""
         }})
     ]
 }};";

                string Path = $"{Project.Path}\\";
                if (!Directory.Exists(Path))
                { Directory.CreateDirectory(Path); }

                WinFormConfigurationComponent.CreateFile(
                $"{Path}Webpack.config.vendor.js",
                Content,
                true);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}

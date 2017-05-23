var webpackMerge = require('webpack-merge');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var commonConfig = require('./webpack.common.js');
var helpers = require('./helpers');
const WriteFilePlugin = require('write-file-webpack-plugin');

module.exports = webpackMerge(commonConfig, {
    //devtool: 'cheap-module-eval-source-map',
    devtool: 'source-map',

    output: {
        path: helpers.root('dist'),
        publicPath: 'http://localhost:8086/',
        filename: '[name].js',
        chunkFilename: '[id].chunk.js'
    },

    plugins: [
      new ExtractTextPlugin('[name].css'),
      new WriteFilePlugin()
    ],

    devServer: {
        historyApiFallback: true,
        stats: 'minimal'
    }
});

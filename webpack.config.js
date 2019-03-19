var path = require('path');

module.exports = {
    entry: './wwwroot/scripts/webMain.ts',
    output: {
        path: path.resolve(__dirname, './wwwroot/dist'),
        filename: 'webpack.bundles.js'
    },
    module: {
        rules: [
            {
                test: /\.scss$/,
                use: ["style-loader", "sass-loader", "css-loader"]
            },
            {
                test: /\.ts$/,
                use: ["ts-loader"]
            }
        ]
    },
    watch: true
};
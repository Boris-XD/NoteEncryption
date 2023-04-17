const HtmlWebPackPlugin = require('html-webpack-plugin');
const path = require('path');

const htmlPlugin = new HtmlWebPackPlugin({
  template: './public/index.html',
  filename: './index.html',
});

module.exports = {
  devtool: 'source-map',
  output: {
    path: path.resolve(__dirname, 'dist'),
    filename: 'bundle.js',
    publicPath: '/',
  },
  mode: 'development',
  resolve: {
    extensions: ['.js', '.jsx'],
    alias: {
      '@components': path.resolve(__dirname, 'src/components/'),
      '@list': path.resolve(__dirname, 'src/components/List/'),
      '@pathuseFetch': path.resolve(__dirname, 'src/services/useFetch'),
      '@pathSendPut': path.resolve(__dirname, 'src/services/SendPut'),
      '@pathSendDelete': path.resolve(__dirname, 'src/services/SendDelete'),
      '@pathHeader': path.resolve(__dirname, 'src/layout/Header'),
      '@pathGeneral': path.resolve(__dirname, 'src/layout/General'),
      '@pathSendGet': path.resolve(__dirname, 'src/services/SendGet'),
      '@pathstylesindex': path.resolve(__dirname, 'src/styles/index'),
      '@pathUserContext': path.resolve(__dirname, 'src/context/UserContext'),
      '@pathListContext': path.resolve(__dirname, 'src/context/ListContext'),
      '@pathvalidatePassword': path.resolve(
        __dirname,
        'src/helpers/validatePassword'
      ),
      '@pathSendPost': path.resolve(__dirname, 'src/services/SendPost'),
      '@pathSendPut': path.resolve(__dirname, 'src/services/SendPut'),
      '@pathGet': path.resolve(__dirname, 'src/services/information/Get'),
      '@pathPut': path.resolve(__dirname, 'src/services/information/Put'),
      '@pathPost': path.resolve(__dirname, 'src/services/information/Post'),
      '@pathDelete': path.resolve(__dirname, 'src/services/information/Delete'),
      '@pathShare': path.resolve(__dirname, 'src/services/information/Share'),
    },
  },
  module: {
    rules: [
      {
        test: /\.(js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
        },
      },
      {
        test: /\.css$/,
        use: ['style-loader', 'css-loader'],
      },
    ],
  },
  plugins: [htmlPlugin],
  devServer: {
    static: {
      directory: path.join(__dirname, 'dist'),
    },
    compress: true,
    historyApiFallback: true,
    port: 3000,
  },
};

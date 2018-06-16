var fn = function () {
  var widget_link, iframe, i, widget_links;
  conv_url = document.getElementsByClassName('botsoc')[0];
  var size = conv_url.target;
  iframe = document.createElement('iframe');
  iframe.setAttribute('src', conv_url.href);
  iframe.setAttribute('width', '342');
  iframe.setAttribute('height', '606');
  iframe.setAttribute('frameborder', '0');
  iframe.setAttribute('scrolling', 'no');
  if (!size) {
    size = 'big';
  }
  if (size === 'big') {
    iframe.setAttribute('style', 'position:relative;left:24px;top:0px; width: 342px; height: 606px;')
  }
  if (size === 'medium') {
    iframe.setAttribute('style', 'position:relative;left:-15px;top:-59px;-webkit-transform:scale(0.8);-moz-transform-scale(0.8); width: 342px; height: 606px;')
  }
  if (size === 'small') {
    iframe.setAttribute('style', 'position:relative;left:-54px;top:-119px;-webkit-transform:scale(0.6);-moz-transform-scale(0.6); width: 342px; height: 606px;')
  }
  var div = document.createElement('div');
  //div.setAttribute('onClick', "window.open('https://botsociety.io/?utm_source=embed&utm_medium="+parent.document.location+"', '_newtab')");
  //iframe.setAttribute('onClick', "window.open('https://botsociety.io','_newtab')");
  if (size === 'big') {
    div.setAttribute('style', 'background-image:url(https://d2d9a1sv0xqzzt.cloudfront.net/node/010/images/iphone6_preview.svg);padding-top: 97px;background-repeat: no-repeat;width:390px;background-size:100%;background-position: 50% 3px;height:797px;overflow:hidden;')
  }
  if (size === 'medium') {
    div.setAttribute('style', 'background-image:url(https://d2d9a1sv0xqzzt.cloudfront.net/node/010/images/iphone6_preview.svg);padding-top: 78px;background-repeat: no-repeat;width:312px;background-size:100%;background-position: 50% 3px;height:637px !important;overflow:hidden;')
  }
  if (size === 'small') {
    div.setAttribute('style', 'background-image:url(https://d2d9a1sv0xqzzt.cloudfront.net/node/010/images/iphone6_preview.svg);padding: 58px 0;background-repeat: no-repeat;width:234px;background-size:100%;background-position: 50% 3px;height:478px;overflow:hidden;')
  }
  div.appendChild(iframe);
  var imagediv = document.createElement('div');
  if (size === 'big') {
    imagediv.setAttribute('style', 'position:relative;bottom:-27px;z-index:10;opacity:0.2;width:100%;text-align:center;');
  }
  if (size === 'medium') {
    imagediv.setAttribute('style', 'position:relative;bottom:109px;z-index:10;opacity:0.2;width:100%;text-align:center;');
  }
  if (size === 'small') {
    imagediv.setAttribute('style', 'position:relative;bottom:229px;z-index:10;opacity:0.2;width:100%;text-align:center;');
  }
  var a = document.createElement('a');
  a.setAttribute('href', 'https://botsociety.io/?utm_source=embed&utm_medium=' + parent.document.location);
  a.setAttribute('target', '_new');
  a.setAttribute('style', 'text-decoration:none;color:#44454c;')
  var trackImg = document.createElement('img');
  trackImg.setAttribute('src', 'https://app.botsociety.io/embTrack?c=' + conv_url.href + '&q=' + parent.document.location)
  trackImg.setAttribute('style', 'height:0px;width:0px;opacity:0;')
  div.appendChild(trackImg);
  var img = document.createElement('img');
  img.setAttribute('src', 'https://d2d9a1sv0xqzzt.cloudfront.net/node/001/images/botsociety_logo_big.png')
  if (size === 'big') {
    img.setAttribute('style', 'max-width: 140px');
  }
  if (size === 'medium') {
    img.setAttribute('style', 'max-width: 112px');
  }
  if (size === 'small') {
    img.setAttribute('style', 'max-width: 84px');
  }
  var p = document.createElement('p');
  p.innerHTML = "Designed with";
  if (size === 'big' || size === 'medium') {
    p.setAttribute('style', 'margin:0px;font-family:Arial!important;font-size:13px!important;padding-bottom:0px;');
  }
  if (size === 'small') {
    p.setAttribute('style', 'margin:0px;font-family:Arial!important;font-size:10px!important;');
  }
  a.appendChild(p);
  a.appendChild(img);
  imagediv.appendChild(a);
  div.appendChild(imagediv);
  conv_url.parentNode.replaceChild(div, conv_url);
}
document.addEventListener('DOMContentLoaded', fn, false);
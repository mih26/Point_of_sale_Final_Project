export class AppConstants {
  static apiUrl = "http://localhost:5168";
  static webUrl = "http://localhost:5001";
  static appName = "Shop Smart";
  static navItems = [
    {
      label: 'Home',
      icon: 'home',
      link: '/home'
    },
    {
      'label':'Suppliers',
      icon: 'front_loader',
      link: '/suppliers'
    },
    {
      'label':'Inventories',
      icon: 'inventory',
      link: '/inventories'
    },
    {
      'label':'Stock',
      icon: 'dns',
      link: '/stock-entries'
    },
    {
      'label':'Product selfing',
      icon: 'data_array',
      link: '/selfed-products'
    }
  ];
}

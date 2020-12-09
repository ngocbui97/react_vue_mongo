import React, { Component } from 'react';
import { Button, Image, Header, Card, Divider } from 'semantic-ui-react';
import history from '../../common/history';
import './index.scss';

class Body extends Component {
  constructor(props) {
    super(props);
    this.state = {
      signIn: false,
      candidates: [
        {
          id: 1,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://images.unsplash.com/photo-1513097633097-329a3a64e0d4?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&w=1000&q=80'
        },
        {
          id: 2,
          name: 'thuy tien',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRNGAO-_eaB-Gmo3NaMsr9dR9Xn8-3084BDyA&usqp=CAU'
        },
        {
          id: 3,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTcsrN6oI4MciEHUchlpr5jsqiwDCIjNSaUPA&usqp=CAU'
        },
        {
          id: 4,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcQXMXvL_fBmk33D8vlGGqD63fHa0l9obLXmvw&usqp=CAU'
        },
        {
          id: 5,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://vn-test-11.slatic.net/p/3e7189a7c3278e089ac360be2f2f0bd1.jpg_1200x1200q80.jpg_.webp'
        },
        {
          id: 6,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR3ztuBYkvdsL5PKloa089Nz5oj7Bg-BAbrEg&usqp=CAU'
        },
        {
          id: 7,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcRF0z54_Ug0u0uSLpE2dSJl9AEBBMUMQplQDA&usqp=CAU'
        },
        {
          id: 8,
          name: 'Leanne Graham',
          username: 'Bret',
          email: 'Sincere@april.biz',
          address: 'Nho phuoc',
          phone: '1-770-736-8031 x56442',
          website: 'hildegard.org',
          company: 'Romaguera-Crona',
          url:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTCk9IcUgkBBc13MRzX_Dq0HLXogcYy4CMTjA&usqp=CAU'
        }
      ],
      jobs: [
        {
          id: 1,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://brannetmarket.com/wp-content/uploads/2018/08/BRALOGO04.jpg'
        },
        {
          id: 2,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcTep_oZA-IwUa6dg3hNGNqRSkKuTw7l0mtYVQ&usqp=CAU'
        },
        {
          id: 3,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://en.ephoto360.com/uploads/worigin/2019/10/04/Free_Company_Logo_Maker5d96f317d259c_5915b2915c1af849b75fcc9cf981b5c3.jpg'
        },
        {
          id: 4,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://www.fotojet.com/template-imgs-thumb/design/company-logo/company-logo-01.jpg'
        },
        {
          id: 5,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://dynamic.brandcrowd.com/asset/logo/021f5af0-4390-4ca6-bf0e-cf0f83c5a173/logo?v=4'
        },
        {
          id: 6,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcR9nS21qlQQmvlrWPL4kEixfNWurjN0vY1tvQ&usqp=CAU'
        },
        {
          id: 7,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://i.pinimg.com/originals/0f/5b/6f/0f5b6f679050f784e42ebb778dc395e5.png'
        },
        {
          id: 8,
          title: '.Net dev',
          description: 'Maintain project about asp.net c#',
          language: 'english',
          yearExperience: 1,
          companyName: 'Nec',
          url_campany:
            'https://dynamic.brandcrowd.com/asset/logo/7a61d944-addb-44ab-91c8-cda41786e9e4/logo?v=4'
        }
      ]
    };
  }

  render() {
    return (
      <div className="body">
        <div className="ui bg-main-body">
          <div className="wellcome">
            <Header as="h1" textAlign="center" className="title-header">
              Go find job or candidate with jobViet
            </Header>
            <Button className="button-find-job" color="yellow">
              Find job
            </Button>
            <Button color="yellow">Find candidate</Button>
          </div>
        </div>
        <Divider className="divider-body"></Divider>
        <div className="new-info">
          <Header as="h2" textAlign="left" className="title-new-info">
            New candidates
          </Header>

          {/* new candidate */}
          <Card.Group itemsPerRow={4}>
            {this.state.candidates.map((item, i) => (
              <Card key={i} className="custom-card">
                <Image src={item.url} wrapped ui={false} className="img-card" />
                <Card.Content>
                  <Card.Header>{item.name}</Card.Header>
                  <Card.Meta>
                    <span className="date">Joined in 2015</span>
                  </Card.Meta>
                  <Card.Description>{item.description}</Card.Description>
                </Card.Content>
                <Card.Content extra>
                  {item.email}
                  <br></br>
                  {item.phone}
                </Card.Content>
              </Card>
            ))}
          </Card.Group>

          <Header as="h2" textAlign="left" className="title-new-info">
            New jobs
          </Header>

          {/* new job */}
          <Card.Group itemsPerRow={4}>
            {this.state.jobs.map((item, i) => (
              <Card key={i} className="custom-card">
                <Image
                  src={item.url_campany}
                  wrapped
                  ui={false}
                  className="img-card"
                />
                <Card.Content>
                  <Card.Header>{item.title}</Card.Header>
                  <Card.Meta>
                    <span>{item.companyName}</span>
                  </Card.Meta>
                </Card.Content>
                <Card.Content extra>
                  <span>Language: </span>
                  {item.language}
                  <br></br>
                  <span>Year experience: </span> {item.yearExperience}
                </Card.Content>
              </Card>
            ))}
          </Card.Group>
        </div>
      </div>
    );
  }
}
export default Body;

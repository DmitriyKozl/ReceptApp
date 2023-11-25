// eslint-disable-next-line no-unused-vars
import React, { useState } from "react";
import {
  Card,
  CardActionArea,
  CardContent,
  CardMedia,
  Checkbox,
  Dialog,
  Grid,
  IconButton,
  ImageList,
  List,
  ListItem,
  Typography,
  Container,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import "../Style/Homepage.css";

const Home = () => {
  const dummydataRecipe = [
    {
      id: 1,
      img: "https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Surprise Chocoladetaart",
    },
    {
      id: 2,
      img: "https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Lasagne Bolognese",
    },
    {
      id: 3,
      img: "https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Aardbei confituur",
    },
    {
      id: 1,
      img: "https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Surprise Chocoladetaart",
    },
    {
      id: 2,
      img: "https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Lasagne Bolognese",
    },
    {
      id: 3,
      img: "https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Aardbei confituur",
    },
    {
      id: 1,
      img: "https://images.unsplash.com/photo-1517427294546-5aa121f68e8a?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Surprise Chocoladetaart",
    },
    {
      id: 2,
      img: "https://images.unsplash.com/photo-1629115916087-7e8c114a24ed?auto=format&fit=crop&q=80&w=1964&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Lasagne Bolognese",
    },
    {
      id: 3,
      img: "https://images.unsplash.com/photo-1610393742736-72b0185368dc?auto=format&fit=crop&q=80&w=1974&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
      name: "Aardbei confituur",
    },
  ];

  const [openPopup, setOpenPopup] = useState(false);

  return (
    <>
      <Grid className="Banner">
        <Typography
          variant="h2"
          sx={{ color: "#fff", m: "-170px 0 0 78px", width: 600, pb: 3 }}
        >
          Shop anything, from any video
        </Typography>
      </Grid>

      <Container
        container
        justify="space-evenly"
        align="center"
        className="Homepage__Container"
        maxWidth="100%"
      >
        <Grid container justify="center" align="center" maxWidth={"100%"}>
          <Grid
            container
            direction="column"
            justify="center"
            align="center"
            xs={2}
            sx={{ flex: 1 }}
          >
            <Typography variant="h2" sx={{ m: "50px auto" }}>
              Filters
            </Typography>
            <List>
              <ListItem>
                <Checkbox />
                <Typography>Lorem Ipsum</Typography>
              </ListItem>
              <ListItem>
                <Checkbox />
                <Typography>Lorem Ipsum</Typography>
              </ListItem>
              <ListItem>
                <Checkbox />
                <Typography>Lorem Ipsum</Typography>
              </ListItem>
            </List>
          </Grid>
          <Grid xs={10} sx={{ flex: 1, m: "auto" }}>
            <Typography variant="h2" sx={{ m: "50px auto" }}>
              Recipes
            </Typography>

            <ImageList
              container
              justify="center"
              align="center"
              width="100%"
              cols={3}
            >
              {dummydataRecipe.map((e) => (
                <Card
                  key={e.id}
                  onClick={() => {
                    setOpenPopup(true);
                  }}
                  sx={{  m: "20px auto", borderRadius: 5, flex:1, flexWrap: 'wrap'}}
                >
                  <CardActionArea>
                    <CardMedia
                      component="div"
                      sx={{
                        minWidth: '300px',

                        paddingTop: "56.25%", 
                        backgroundImage: `url(${e.img})`,
                        backgroundSize: "cover",
                        backgroundPosition: "center",
                      }}
                      alt={e.name}
                    />
                    <CardContent>
                      <Typography variant="h5">{e.name}</Typography>
                    </CardContent>
                  </CardActionArea>
                </Card>
              ))}
            </ImageList>
            <Dialog
              open={openPopup}
              onClose={() => {
                setOpenPopup(false);
              }}
              PaperProps={{
                sx: { borderRadius: "20px", width: 1000, maxWidth: 1000 },
              }}
            >
              <IconButton
                sx={{ position: "absolute", alignSelf: "end" }}
                onClick={() => {
                  setOpenPopup(false);
                }}
              >
                <CloseIcon fontSize="large" />
              </IconButton>
              {/* <VideoPopup values={{}} />  */}
            </Dialog>
          </Grid>
        </Grid>
      </Container>
    </>
  );
};

export default Home;

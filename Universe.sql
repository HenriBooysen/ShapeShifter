--
-- PostgreSQL database dump
--

-- Dumped from database version 12.17 (Ubuntu 12.17-1.pgdg22.04+1)
-- Dumped by pg_dump version 12.17 (Ubuntu 12.17-1.pgdg22.04+1)

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE universe;
--
-- Name: universe; Type: DATABASE; Schema: -; Owner: freecodecamp
--

CREATE DATABASE universe WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'C.UTF-8' LC_CTYPE = 'C.UTF-8';


ALTER DATABASE universe OWNER TO freecodecamp;

\connect universe

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: blackholes; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.blackholes (
    blackholes_id integer NOT NULL,
    name character varying(25),
    radius_in_ly integer,
    mass_in_solar_masses integer NOT NULL,
    galaxy_id integer
);


ALTER TABLE public.blackholes OWNER TO freecodecamp;

--
-- Name: blackholes_blackhole_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.blackholes_blackhole_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.blackholes_blackhole_id_seq OWNER TO freecodecamp;

--
-- Name: blackholes_blackhole_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.blackholes_blackhole_id_seq OWNED BY public.blackholes.blackholes_id;


--
-- Name: galaxy; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.galaxy (
    galaxy_id integer NOT NULL,
    description character varying(50),
    has_life boolean,
    age_in_millions_of_years integer,
    galaxy_type character varying(30),
    distance_from_earth_in_ly integer,
    raduis_in_ly integer,
    name character varying(20) NOT NULL
);


ALTER TABLE public.galaxy OWNER TO freecodecamp;

--
-- Name: galaxy_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.galaxy_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.galaxy_id_seq OWNER TO freecodecamp;

--
-- Name: galaxy_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.galaxy_id_seq OWNED BY public.galaxy.galaxy_id;


--
-- Name: moon; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.moon (
    moon_id integer NOT NULL,
    name character varying(20) NOT NULL,
    raduis_in_thousand_km numeric(4,2),
    description text,
    distance_from_earth_in_hundred_thousand_km integer,
    planet_id integer
);


ALTER TABLE public.moon OWNER TO freecodecamp;

--
-- Name: moon_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.moon_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.moon_id_seq OWNER TO freecodecamp;

--
-- Name: moon_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.moon_id_seq OWNED BY public.moon.moon_id;


--
-- Name: planet; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.planet (
    planet_id integer NOT NULL,
    raduis_in_1000km integer,
    has_life boolean,
    age_in_milion_of_years integer,
    description character varying(50),
    distance_from_earth_in_hundred_thousand_km integer,
    name character varying(20) NOT NULL,
    star_id integer
);


ALTER TABLE public.planet OWNER TO freecodecamp;

--
-- Name: planet_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.planet_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.planet_id_seq OWNER TO freecodecamp;

--
-- Name: planet_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.planet_id_seq OWNED BY public.planet.planet_id;


--
-- Name: star; Type: TABLE; Schema: public; Owner: freecodecamp
--

CREATE TABLE public.star (
    name character varying(20) NOT NULL,
    age_in_milion_of_years integer,
    raduis_in_thousand_of_km integer,
    star_id integer NOT NULL,
    distance_from_earth_in_ly integer,
    description character varying(30),
    brightness integer,
    galaxy_id integer
);


ALTER TABLE public.star OWNER TO freecodecamp;

--
-- Name: star_id_seq; Type: SEQUENCE; Schema: public; Owner: freecodecamp
--

CREATE SEQUENCE public.star_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public.star_id_seq OWNER TO freecodecamp;

--
-- Name: star_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: freecodecamp
--

ALTER SEQUENCE public.star_id_seq OWNED BY public.star.star_id;


--
-- Name: blackholes blackholes_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.blackholes ALTER COLUMN blackholes_id SET DEFAULT nextval('public.blackholes_blackhole_id_seq'::regclass);


--
-- Name: galaxy galaxy_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy ALTER COLUMN galaxy_id SET DEFAULT nextval('public.galaxy_id_seq'::regclass);


--
-- Name: moon moon_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon ALTER COLUMN moon_id SET DEFAULT nextval('public.moon_id_seq'::regclass);


--
-- Name: planet planet_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet ALTER COLUMN planet_id SET DEFAULT nextval('public.planet_id_seq'::regclass);


--
-- Name: star star_id; Type: DEFAULT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star ALTER COLUMN star_id SET DEFAULT nextval('public.star_id_seq'::regclass);


--
-- Data for Name: blackholes; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.blackholes VALUES (1, 'Sagittarius A', 0, 4300000, 1);
INSERT INTO public.blackholes VALUES (2, 'Andromeda A', 0, 110000000, 2);
INSERT INTO public.blackholes VALUES (3, 'Cygnus X-1', 0, 21, 1);
INSERT INTO public.blackholes VALUES (4, 'Sombrero', 0, 660000000, 5);


--
-- Data for Name: galaxy; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.galaxy VALUES (1, 'Our home galaxy', true, 13600, 'Spiral', 0, 52850, 'Milky Way');
INSERT INTO public.galaxy VALUES (2, 'The closest spiral galaxy to us', false, 10000, 'Spiral', 2537, 110000, 'Andromeda');
INSERT INTO public.galaxy VALUES (3, 'A member of the local group', false, 12000, 'Spiral', 3000, 30000, 'Triangulum');
INSERT INTO public.galaxy VALUES (4, 'Known for its distinctive spiral arms', false, 500, 'Spiral', 23000, 30000, 'Whirlpool');
INSERT INTO public.galaxy VALUES (5, 'Famous for looking like a hat', false, 13000, 'Spiral', 31000, 25000, 'Sombrero');
INSERT INTO public.galaxy VALUES (6, 'A giant elliptical galaxy', false, 13700, 'Eliptical', 53500, 60000, 'Messier');


--
-- Data for Name: moon; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.moon VALUES (1, 'Moon', 1.74, 'Earths only natural satelite', 4, 3);
INSERT INTO public.moon VALUES (2, 'Phobos', 0.01, 'One of Marss two moons', 9, 4);
INSERT INTO public.moon VALUES (3, 'Deimos', 0.01, 'The Smaller moon of Mars', 23, 4);
INSERT INTO public.moon VALUES (4, 'Io', 1.82, 'Very volcano active', 422, 5);
INSERT INTO public.moon VALUES (5, 'Europa', 1.56, 'Icy moon', 671, 5);
INSERT INTO public.moon VALUES (6, 'Ganymede', 2.63, 'The largest moon', 1070, 5);
INSERT INTO public.moon VALUES (7, 'Callisto', 2.41, 'A lot of craters', 1883, 5);
INSERT INTO public.moon VALUES (8, 'Titan', 2.60, 'Saturns largest moon', 1222, 6);
INSERT INTO public.moon VALUES (9, 'Enceladus', 0.30, 'Has geysers that eject ice', 1272, 6);
INSERT INTO public.moon VALUES (10, 'Mimas', 0.20, 'Has a large crater called Herchel', 1856, 6);
INSERT INTO public.moon VALUES (11, 'Triton', 1.35, 'Neptuens largest moon', 4500, 7);
INSERT INTO public.moon VALUES (12, 'Nereid', 0.17, 'An irregular moon of Neptune', 6, 7);
INSERT INTO public.moon VALUES (13, 'Oberon', 0.76, 'Second largest moon of Uranus', 2900, 8);
INSERT INTO public.moon VALUES (14, 'Titania', 0.79, 'Largest moon of Uranus', 2900, 8);
INSERT INTO public.moon VALUES (15, 'Umbriel', 0.58, 'A dark moon of uranus', 2900, 8);
INSERT INTO public.moon VALUES (16, 'Ariel', 0.58, 'A very bright surface', 2900, 8);
INSERT INTO public.moon VALUES (17, 'Miranda', 0.24, 'Extreme geological features', 2900, 8);
INSERT INTO public.moon VALUES (18, 'Lapetus', 0.74, 'Two tone color', 128, 7);
INSERT INTO public.moon VALUES (19, 'Hyperion', 0.14, 'Chaotic rotation and shape', 128, 7);
INSERT INTO public.moon VALUES (20, 'Dactl', 0.01, 'Very small', 46, 6);


--
-- Data for Name: planet; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.planet VALUES (1, 2, false, 4500, 'Closest to the sun', 92, 'Mercury', 1);
INSERT INTO public.planet VALUES (2, 6, false, 4500, 'Toxic atmosphere', 41, 'Venus', 1);
INSERT INTO public.planet VALUES (3, 6, true, 4500, 'Our Home Planet', 0, 'Earth', 1);
INSERT INTO public.planet VALUES (4, 3, false, 4500, 'Red Planet', 78, 'Mars', 1);
INSERT INTO public.planet VALUES (5, 70, false, 4500, 'The largest planet in our Solar System', 6287, 'Jupiter', 1);
INSERT INTO public.planet VALUES (6, 58, false, 4500, 'Amazing ring system', 12750, 'Saturn', 1);
INSERT INTO public.planet VALUES (7, 25, false, 4500, 'Blue-green color and extreme axial tilt', 27200, 'Uranus', 1);
INSERT INTO public.planet VALUES (8, 25, false, 4500, 'Farthest from the Sun, extreme winds', 43500, 'Neptune', 1);
INSERT INTO public.planet VALUES (9, 1, false, 4850, 'Closest known exoplanet', 4000000, 'Proxima Centauri b', 2);
INSERT INTO public.planet VALUES (10, 50, false, 8, 'A hypothetical planet', 40800000, 'Betelgeuse b', 3);
INSERT INTO public.planet VALUES (11, 1, false, 237, 'A hypothetical planet', 8600, 'Sirius b', 4);
INSERT INTO public.planet VALUES (12, 2, false, 60, 'A hypothetical planet', 9700, 'Alpheratz b', 5);


--
-- Data for Name: star; Type: TABLE DATA; Schema: public; Owner: freecodecamp
--

INSERT INTO public.star VALUES ('sun', 4600, 696, 1, 0, 'Our Star', 1, 1);
INSERT INTO public.star VALUES ('Alpha Centauri A', 5000, 834, 2, 4, 'The Closeststar to us', 2, 1);
INSERT INTO public.star VALUES ('Betelguese', 10, 617000, 3, 643, 'A red super giant', 126000, 1);
INSERT INTO public.star VALUES ('Sirius A', 242, 1191, 4, 9, 'The brightest star for us', 25, 1);
INSERT INTO public.star VALUES ('Alpheratz', 200, 1500, 5, 97, 'Brightest star in Andromeda', 200, 2);
INSERT INTO public.star VALUES ('NGC604', 3, 1500, 6, 3, 'Close to a star nursery', 6300, 4);


--
-- Name: blackholes_blackhole_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.blackholes_blackhole_id_seq', 4, true);


--
-- Name: galaxy_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.galaxy_id_seq', 6, true);


--
-- Name: moon_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.moon_id_seq', 10, true);


--
-- Name: planet_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.planet_id_seq', 12, true);


--
-- Name: star_id_seq; Type: SEQUENCE SET; Schema: public; Owner: freecodecamp
--

SELECT pg_catalog.setval('public.star_id_seq', 6, true);


--
-- Name: blackholes blackholes_pkey; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.blackholes
    ADD CONSTRAINT blackholes_pkey PRIMARY KEY (blackholes_id);


--
-- Name: galaxy galaxy_id; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy
    ADD CONSTRAINT galaxy_id UNIQUE (galaxy_id);


--
-- Name: galaxy galaxy_idp; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy
    ADD CONSTRAINT galaxy_idp PRIMARY KEY (galaxy_id);


--
-- Name: moon moon_id; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT moon_id UNIQUE (moon_id);


--
-- Name: moon moon_idp; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT moon_idp PRIMARY KEY (moon_id);


--
-- Name: planet planet_id; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT planet_id UNIQUE (planet_id);


--
-- Name: planet planet_idp; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT planet_idp PRIMARY KEY (planet_id);


--
-- Name: star star_id; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT star_id UNIQUE (star_id);


--
-- Name: star star_idp; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT star_idp PRIMARY KEY (star_id);


--
-- Name: blackholes ublackhole_id; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.blackholes
    ADD CONSTRAINT ublackhole_id UNIQUE (blackholes_id);


--
-- Name: galaxy unique_name; Type: CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.galaxy
    ADD CONSTRAINT unique_name UNIQUE (name);


--
-- Name: star fk_galaxy_id; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.star
    ADD CONSTRAINT fk_galaxy_id FOREIGN KEY (galaxy_id) REFERENCES public.galaxy(galaxy_id);


--
-- Name: planet fk_star_id; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.planet
    ADD CONSTRAINT fk_star_id FOREIGN KEY (star_id) REFERENCES public.star(star_id);


--
-- Name: moon fmoon_id; Type: FK CONSTRAINT; Schema: public; Owner: freecodecamp
--

ALTER TABLE ONLY public.moon
    ADD CONSTRAINT fmoon_id FOREIGN KEY (planet_id) REFERENCES public.planet(planet_id);


--
-- PostgreSQL database dump complete
--


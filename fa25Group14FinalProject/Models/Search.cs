using fa25Group14FinalProject.Models.SearchViewModel;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using System;
using System.Numerics;

@model SearchViewModel

<form asp-action="DisplaySearchResults" method="post">

    <div class= "form-group" >
        < label > Title </ label >
        < input asp -for= "Title" class= "form-control" />
    </ div >

    < div class= "form-group" >
        < label > Author </ label >
        < input asp -for= "Author" class= "form-control" />
    </ div >

    < div class= "form-group" >
        < label > Unique Number </ label >
        < input asp -for= "UniqueNumber" class= "form-control" />
    </ div >

    < div class= "form-group" >
        < label > Genre </ label >
        < select asp -for= "GenreID" asp - items = "ViewBag.AllGenres" class= "form-select" >
            < option value = "" > --All Genres-- </ option >
        </ select >
    </ div >

    < div class= "form-group" >
        < label > Sort By </ label >
        < select asp -for= "SortOption" class= "form-select" >
            < option value = "Title" > Title </ option >
            < option value = "Author" > Author </ option >
            < option value = "MostPopular" > Most Popular </ option >
            < option value = "Newest" > Newest </ option >
            < option value = "Oldest" > Oldest </ option >
            < option value = "HighestRated" > Highest Rated </ option >
        </ select >
    </ div >

    < div >
        < input type = "checkbox" asp -for= "InStockOnly" /> In Stock Only
    </ div >

    < button type = "submit" class= "btn btn-primary" > Search </ button >
    < a asp - action = "DisplaySearchResults" class= "btn btn-secondary" > Show All </ a >

</ form >

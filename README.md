# README

## What's this about?

It's a really quick demonstration of using a technology/implementation agnostic specification written 
in your domain model's ubiquitous language to drive tests at multiple levels of your test pyramid.

## Excuses

This repo contains terrible examples of:

* Specflow Steps.
* Selenium tests.
* Managing the Selenium driver life cycle.
* Clean code.

I did it in an hour while watching [Fallout: New Vegas Multiplayer.](https://www.youtubetrimmer.com/view/?v=DyY0hbilfC4&start=1399&end=1420&loop=0) 
The feels :sob:.

It's only for demonstrating the _concept_ of writing specifications in your ubqiquitous language
rather than writing test scripts coupled to a particular technology (e.g. open browser, navigate to page, click button)

Ironically, it's not even a _great_ example of a gherkin spec or a ubiquitous language.

## Gotchas

This repo uses symlinks to enable the same feature files to be used to generate tests in multiple projects, 
as a workaround to Specflow's lack of glue.

If you are on Windows then you need to either:

* Enable development mode and forget about it

or:

* Enable symlink creation in your git config.
* Make sure you are elevated when you `git clone`.
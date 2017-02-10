require 'distances'

class Cell
    attr_reader :row, :column
    attr_accessor :north, :south, :west, :east

    def initialize(row, column)
        @row, @column = row, column
        @links = {}
    end

    def link(cell, bidi=true)
        @links[cell] = true
        cell.link(self, false) if bidi
        self
    end

    def unlink(cell, bidi=true)
        @links.delete(cell)
        cell.unlink(self,false) if bidi
        self
    end

    def links
        @links.keys
    end

    def linked?(cell)
        @links.key?(cell)
    end

    def neighbors
        list=[]
        list << north if north
        list << west if west
        list << south if south
        list << east if east
        list
    end

    def distances
        distances = Distances.new(self)
        frontier = [ self ]

        while frontier.any?
            new_frontier = []

            frontier.each do |frontier_cell|
                frontier_cell.links.each do |linked_cell|
                    next if distances[linked_cell]
                    distances[linked_cell] = distances[frontier_cell] + 1
                    new_frontier << linked_cell
                end 
            end

            frontier = new_frontier
        end

        distances
    end
end